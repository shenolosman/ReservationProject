using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _subscribeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddService(MailSubscribe subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var findId = _subscribeService.TGetById(id);
            _subscribeService.TDelete(findId);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(MailSubscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetService(int id)
        {
            return Ok(_subscribeService.TGetById(id));
        }
    }
}
