using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddContact(Contact model)
        {
            model.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetReceiverContact(int id)
        {
            return Ok(_contactService.TGetById(id));
        }
    }
}
