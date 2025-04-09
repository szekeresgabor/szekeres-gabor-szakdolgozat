using AutoMapper;
using szerzodeskezelo_api.Data;
using szerzodeskezelo_api.Models;

namespace szerzodeskezelo_api.Mapping;

public class SzerzodesProfile : Profile
{
    public SzerzodesProfile()
    {
        CreateMap<Szerzodes, SzerzodesDto>().ReverseMap();
    }
}
