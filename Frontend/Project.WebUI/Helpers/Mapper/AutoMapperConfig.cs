using AutoMapper;
using Project.EntityLayer.Concrete;
using Project.WebUI.Dtos.AboutUsDto;
using Project.WebUI.Dtos.AppUserDto;
using Project.WebUI.Dtos.BookingDto;
using Project.WebUI.Dtos.RoomDto;
using Project.WebUI.Dtos.ServiceDto;
using Project.WebUI.Dtos.StaffDto;
using Project.WebUI.Dtos.SubscribeDto;
using Project.WebUI.Dtos.TestimonialDto;

namespace Project.WebUI.Helpers.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();
            CreateMap<CreateStaffDto, Staff>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<CreateAppUserDto, AppUser>().ReverseMap();
            CreateMap<LoginAppUserDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutUsDto, AboutUs>().ReverseMap();
            CreateMap<UpdateAboutUsDto, AboutUs>().ReverseMap();
           
            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();

            CreateMap<CreateSubscribeDto, MailSubscribe>().ReverseMap();
            CreateMap<ResultSubscribeDto, MailSubscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();

        }
    }
}
