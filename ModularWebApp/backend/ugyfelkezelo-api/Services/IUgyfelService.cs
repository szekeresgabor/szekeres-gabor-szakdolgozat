using System;
using ugyfelkezelo_api.Data;
using ugyfelkezelo_api.Models;

namespace ugyfelkezelo_api.Services;

public interface IUgyfelService
{
    Task<IEnumerable<UgyfelDto>> GetAllAsync();
    Task<UgyfelDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(UgyfelDto dto);
    Task<bool> UpdateAsync(Guid id, UgyfelDto dto);
    Task<bool> DeleteAsync(Guid id);
}