using AutoMapper;
using Core.Backend.Package.Data;
using szerzodeskezelo_api.Data;
using szerzodeskezelo_api.Models;

namespace szerzodeskezelo_api.Services;

public class SzerzodesService : ISzerzodesService
{
    private readonly IGenericRepository<Szerzodes> _repo;
    private readonly IMapper _mapper;

    public SzerzodesService(IGenericRepository<Szerzodes> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SzerzodesDto>> GetAllAsync()
    {
        var szerzodesek = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<SzerzodesDto>>(szerzodesek);
    }

    public async Task<SzerzodesDto?> GetByIdAsync(Guid id)
    {
        var szerzodes = await _repo.GetByIdAsync(id);
        return szerzodes == null ? null : _mapper.Map<SzerzodesDto>(szerzodes);
    }

    public async Task<Guid> CreateAsync(SzerzodesDto dto)
    {
        var szerzodes = _mapper.Map<Szerzodes>(dto);
        szerzodes.Id = Guid.NewGuid();
        szerzodes.CreatedAt = DateTime.UtcNow;
        await _repo.AddAsync(szerzodes);
        await _repo.SaveChangesAsync();
        return szerzodes.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, SzerzodesDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        existing.ModifiedAt = DateTime.UtcNow;
        _repo.Update(existing);
        await _repo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;

        _repo.Delete(existing);
        await _repo.SaveChangesAsync();
        return true;
    }
}