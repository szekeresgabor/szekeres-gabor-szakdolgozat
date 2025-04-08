using panaszkezelo_api.Models;

namespace panaszkezelo_api.Services;

public interface IPanaszService
{
    Task<IEnumerable<PanaszDto>> GetAllAsync();
    Task<PanaszDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(PanaszDto dto);
    Task<bool> UpdateAsync(Guid id, PanaszDto dto);
    Task<bool> DeleteAsync(Guid id);
}