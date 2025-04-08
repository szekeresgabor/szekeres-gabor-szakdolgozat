using AutoMapper;
using panaszkezelo_api.Data;
using panaszkezelo_api.Models;

namespace panaszkezelo_api.Mapping;

public class PanaszProfile : Profile
{
    public PanaszProfile()
    {
        CreateMap<Panasz, PanaszDto>().ReverseMap();
    }
}
