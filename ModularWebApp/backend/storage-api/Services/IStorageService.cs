using Microsoft.AspNetCore.Mvc;

namespace storage_api.Services;

public interface IStorageService
{
    Task<Guid> UploadFileAsync(IFormFile file);
    Task<FileStreamResult?> GetFileAsync(Guid id);
    Task<bool> DeleteFileAsync(Guid id);

    Task<string> GetFileNameAsync(Guid id);
}