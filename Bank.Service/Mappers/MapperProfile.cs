using AutoMapper;
using Bank.Domain.Entites;
using Bank.Service.DTOs;

namespace Bank.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserForCreationDto, User>().ReverseMap();
            CreateMap<UserForResultDto, User>().ReverseMap();   
        }
    }
}
