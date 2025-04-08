using AutoMapper;
using Core.Backend.Package.Data;
using panaszkezelo_api.Data;
using panaszkezelo_api.Models;

namespace panaszkezelo_api.Services;

public class PanaszService : IPanaszService
{
    private readonly IGenericRepository<Panasz> _repo;
    private readonly IMapper _mapper;

    public PanaszService(IGenericRepository<Panasz> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PanaszDto>> GetAllAsync()
    {
        var panaszok = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<PanaszDto>>(panaszok);
    }

    public async Task<PanaszDto?> GetByIdAsync(Guid id)
    {
        var panasz = await _repo.GetByIdAsync(id);
        return panasz == null ? null : _mapper.Map<PanaszDto>(panasz);
    }

    public async Task<Guid> CreateAsync(PanaszDto dto)
    {
        var panasz = _mapper.Map<Panasz>(dto);
        panasz.Id = Guid.NewGuid();
        panasz.CreatedAt = DateTime.UtcNow;
        await _repo.AddAsync(panasz);
        await _repo.SaveChangesAsync();
        return panasz.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, PanaszDto dto)
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