using System;
using Core.Backend.Package.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using szerzodeskezelo_api.Models;
using szerzodeskezelo_api.Services;

namespace szerzodeskezelo_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[RoleRequired("szerzodeskezelo")]
public class SzerzodesController : ControllerBase
{
    private readonly ISzerzodesService _service;

    public SzerzodesController(ISzerzodesService service)
    {
        _service = service;
    }

    [HttpGet]
    [PermissionRequired("szerzodeskezelo.read")]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    [PermissionRequired("szerzodeskezelo.read")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var szerzodes = await _service.GetByIdAsync(id);
        return szerzodes == null ? NotFound() : Ok(szerzodes);
    }

    [HttpPost]
    [PermissionRequired("szerzodeskezelo.edit")]
    public async Task<IActionResult> Create([FromBody] SzerzodesDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id}")]
    [PermissionRequired("szerzodeskezelo.edit")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SzerzodesDto dto)
        => await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    [PermissionRequired("szerzodeskezelo.delete")]
    public async Task<IActionResult> Delete(Guid id)
        => await _service.DeleteAsync(id) ? NoContent() : NotFound();
}