using AutoMapper;
using Core.Backend.Package.Data;
using ugyfelkezelo_api.Data;
using ugyfelkezelo_api.Models;

namespace ugyfelkezelo_api.Services;
public class UgyfelService : IUgyfelService
{
    private readonly IGenericRepository<Ugyfel> _repository;
    private readonly IMapper _mapper;

    public UgyfelService(IGenericRepository<Ugyfel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UgyfelDto>> GetAllAsync()
    {
        var ugyfelek = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<UgyfelDto>>(ugyfelek);
    }

    public async Task<UgyfelDto?> GetByIdAsync(Guid id)
    {
        var ugyfel = await _repository.GetByIdAsync(id);
        return ugyfel == null ? null : _mapper.Map<UgyfelDto>(ugyfel);
    }

    public async Task<Guid> CreateAsync(UgyfelDto dto)
    {
        var entity = _mapper.Map<Ugyfel>(dto);
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, UgyfelDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        _mapper.Map(dto, entity);
        entity.ModifiedAt = DateTime.UtcNow;
        _repository.Update(entity);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        _repository.Delete(entity);
        await _repository.SaveChangesAsync();
        return true;
    }
}