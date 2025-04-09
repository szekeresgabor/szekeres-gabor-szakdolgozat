using Core.Backend.Package.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ugyfelkezelo_api.Models;
using ugyfelkezelo_api.Services;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[RoleRequired("ugyfelkezelo")]
public class UgyfelController : ControllerBase
{
    private readonly IUgyfelService _service;

    public UgyfelController(IUgyfelService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UgyfelDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return Ok(new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UgyfelDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? Ok() : NotFound();
    }
}