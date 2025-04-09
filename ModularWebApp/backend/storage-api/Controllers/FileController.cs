using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using storage_api.Services;

namespace storage_api.Controllers;

[ApiController]
[Authorize]
[Route("api/files")]
public class FileController : ControllerBase
{
    private readonly IStorageService _storageService;

    public FileController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var id = await _storageService.UploadFileAsync(file);
        return Ok(new { id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Download(Guid id)
    {
        var result = await _storageService.GetFileAsync(id);
        return result is null ? NotFound() : result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _storageService.DeleteFileAsync(id);
        return success ? Ok() : NotFound();
    }
}