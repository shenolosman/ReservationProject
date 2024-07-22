using AutoMapper;
using Project.DtoLayer.Dtos.RoomDto;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();
        }
    }
}
