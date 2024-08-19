using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking model)
        {
            _bookingService.TInsert(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var findId = _bookingService.TGetById(id);
            _bookingService.TDelete(findId);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBooking(Booking model)
        {
            _bookingService.TUpdate(model);
            return Ok();
        }
     
        [HttpGet("BookingApproved/{id}")]
        public IActionResult BookingApproved(int id)
        {
            _bookingService.TBookingStatusChangeApprovedWithId(id);
            return Ok();
        }
        [HttpGet("BookingDeclined/{id}")]
        public IActionResult BookingDeclined(int id)
        {
            _bookingService.TBookingStatusChangeDeclineWithId(id);
            return Ok();
        }
        [HttpGet("BookingWait/{id}")]
        public IActionResult BookingWait(int id)
        {
            _bookingService.TBookingStatusChangeWaitWithId(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            return Ok(_bookingService.TGetById(id));
        }
        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
            return Ok(_bookingService.TLast6Booking());
        }
        
    }
}
