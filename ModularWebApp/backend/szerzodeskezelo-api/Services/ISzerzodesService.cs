using szerzodeskezelo_api.Models;

namespace szerzodeskezelo_api.Services;

public interface ISzerzodesService
{
    Task<IEnumerable<SzerzodesDto>> GetAllAsync();
    Task<SzerzodesDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(SzerzodesDto dto);
    Task<bool> UpdateAsync(Guid id, SzerzodesDto dto);
    Task<bool> DeleteAsync(Guid id);
}