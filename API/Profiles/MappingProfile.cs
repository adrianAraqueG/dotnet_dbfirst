using AutoMapper;
using API.Dtos;
using Core.Entities;

namespace API.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile(){

        CreateMap<Driver, DriverDto>().ReverseMap();
        
        CreateMap<Team, TeamDto>().ReverseMap();
    }
}