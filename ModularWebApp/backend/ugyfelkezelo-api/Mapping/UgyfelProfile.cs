using AutoMapper;
using ugyfelkezelo_api.Data;
using ugyfelkezelo_api.Models;

namespace ugyfelkezelo_api.Mapping;

public class UgyfelProfile : Profile
{
    public UgyfelProfile()
    {
        CreateMap<Ugyfel, UgyfelDto>().ReverseMap();
    }
}
