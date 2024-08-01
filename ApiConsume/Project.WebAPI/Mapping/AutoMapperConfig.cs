using AutoMapper;
using Project.DtoLayer.Dtos.RoomDto;
using Project.DtoLayer.Dtos.TestimonialDto;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>().ReverseMap();
            CreateMap<RoomUpdateDto, Room>().ReverseMap();

            CreateMap<TestimonialAddDto, Testimonial>().ReverseMap();
        }
    }
}
