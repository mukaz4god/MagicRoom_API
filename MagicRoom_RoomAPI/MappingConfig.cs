using AutoMapper;
using MagicHouse_HouseAPI.Models;
using MagicHouse_HouseAPI.Models.Dto;

namespace MagicHouse_HouseAPI
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
