using Core.Backend.Package.Data;
using Microsoft.AspNetCore.Mvc;
using storage_api.Data;

namespace storage_api.Services;

public class StorageService : IStorageService
{
    private readonly IGenericRepository<StoredFile> _repository;
    private readonly IWebHostEnvironment _env;

    public StorageService(IGenericRepository<StoredFile> repository, IWebHostEnvironment env)
    {
        _repository = repository;
        _env = env;
    }

    public async Task<Guid> UploadFileAsync(IFormFile file)
    {
        var id = Guid.NewGuid();
        var uploadsPath = Path.Combine(_env.ContentRootPath, "uploads");
        Directory.CreateDirectory(uploadsPath);

        var filePath = Path.Combine(uploadsPath, id.ToString());

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var storedFile = new StoredFile
        {
            Id = id,
            FileName = file.FileName,
            FilePath = filePath,
            ContentType = file.ContentType ?? "application/octet-stream",
            Size = file.Length
        };

        await _repository.AddAsync(storedFile);
        await _repository.SaveChangesAsync();

        return id;
    }

    public async Task<FileStreamResult?> GetFileAsync(Guid id)
    {
        var file = await _repository.GetByIdAsync(id);
        if (file == null || !File.Exists(file.FilePath))
            return null;

        var stream = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read);
        return new FileStreamResult(stream, file.ContentType)
        {
            FileDownloadName = file.FileName
        };
    }

    public async Task<bool> DeleteFileAsync(Guid id)
    {
        var file = await _repository.GetByIdAsync(id);
        if (file == null)
            return false;

        if (File.Exists(file.FilePath))
            File.Delete(file.FilePath);

        _repository.Delete(file);
        await _repository.SaveChangesAsync();

        return true;
    }
}