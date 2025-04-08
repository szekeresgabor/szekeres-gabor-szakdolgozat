using System;
using Core.Backend.Package.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using panaszkezelo_api.Models;
using panaszkezelo_api.Services;

namespace panaszkezelo_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[RoleRequired("panaszkezelo")]
public class PanaszController : ControllerBase
{
    private readonly IPanaszService _service;

    public PanaszController(IPanaszService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var panasz = await _service.GetByIdAsync(id);
        return panasz == null ? NotFound() : Ok(panasz);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PanaszDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PanaszDto dto)
        => await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
        => await _service.DeleteAsync(id) ? NoContent() : NotFound();
}