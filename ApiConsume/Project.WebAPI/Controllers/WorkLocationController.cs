using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }
        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _workLocationService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddGuest(WorkLocation model)
        {
            _workLocationService.TInsert(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var findId = _workLocationService.TGetById(id);
            _workLocationService.TDelete(findId);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGuest(WorkLocation model)
        {
            _workLocationService.TUpdate(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            return Ok(_workLocationService.TGetById(id));
        }
    }
}
