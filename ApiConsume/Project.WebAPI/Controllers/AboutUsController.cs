using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.EntityLayer.Concrete;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IMapper _mapper;

        public AboutUsController(IAboutUsService aboutUsService, IMapper mapper)
        {
            _aboutUsService = aboutUsService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AboutUsList()
        {
            var values = _aboutUsService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAboutUs(AboutUs aboutUs)
        {
            if (!ModelState.IsValid) return BadRequest();
            var values = _mapper.Map<AboutUs>(aboutUs);
            _aboutUsService.TInsert(values);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAboutUs(int id)
        {
            var findId = _aboutUsService.TGetById(id);
            _aboutUsService.TDelete(findId);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAboutUs(AboutUs aboutUs)
        {
            if (!ModelState.IsValid) return BadRequest();
            var values = _mapper.Map<AboutUs>(aboutUs);
            _aboutUsService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAboutUs(int id)
        {
            return Ok(_aboutUsService.TGetById(id));
        }
    }
}
