using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessageCategoryController : ControllerBase
    {
        private readonly IContactMessageCategoryService _contactMessageCategoryService;

        public ContactMessageCategoryController(IContactMessageCategoryService contactMessageCategoryService)
        {
            _contactMessageCategoryService = contactMessageCategoryService;
        }
        [HttpGet]
        public IActionResult ContactMessageCategoryList()
        {
            var values = _contactMessageCategoryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddContactMessageCategory(ContactMessageCategory model)
        {
            _contactMessageCategoryService.TInsert(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetReceiverContactMessageCategory(int id)
        {
            return Ok(_contactMessageCategoryService.TGetById(id));
        }
    }
}
