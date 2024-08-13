using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult AppUserList()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }
        //[HttpPost]
        //public IActionResult AddBooking(AppUser model)
        //{
        //    _appUserService.TInsert(model);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult DeleteBooking(int id)
        //{
        //    var findId = _appUserService.TGetById(id);
        //    _appUserService.TDelete(findId);
        //    return Ok();
        //}
        //[HttpPut]
        //public IActionResult UpdateBooking(AppUser model)
        //{
        //    _appUserService.TUpdate(model);
        //    return Ok();
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetBooking(int id)
        //{
        //    return Ok(_appUserService.TGetById(id));
        //}
        [HttpGet("UserWithWorkLocationList")]
        public IActionResult UserWithWorkLocationList()
        {
            var values = _appUserService.TUserListWithWorkLocation();
            return Ok(values);
        }
    }
}
