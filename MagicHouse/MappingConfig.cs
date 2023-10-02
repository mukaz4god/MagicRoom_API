using AutoMapper;
using MagicHouse.Models;
using MagicHouse.Models.Dto;

namespace MagicHouse
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<House, HouseDto>().ReverseMap();
            CreateMap<RoomNumber, RoomNumberDto>().ReverseMap();
        }
    }
}
