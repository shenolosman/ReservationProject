using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.Dtos.RoomDto;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(RoomAddDto room)
        {
            if (!ModelState.IsValid) return BadRequest();
            var values = _mapper.Map<Room>(room);
            _roomService.TInsert(values);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var findId = _roomService.TGetById(id);
            _roomService.TDelete(findId);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto room)
        {
            if (!ModelState.IsValid) return BadRequest();
            var values = _mapper.Map<Room>(room);
            _roomService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            return Ok(_roomService.TGetById(id));
        }
    }
}
