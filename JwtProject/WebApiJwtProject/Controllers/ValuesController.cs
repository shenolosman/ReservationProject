﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiJwtProject.Models;

namespace WebApiJwtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public  IActionResult Test()
        {
            return Ok(new CreateToken().TokenGenerate());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Welcome");
        }
        [HttpGet("[action]")]
        public IActionResult Test4()
        {
            return Ok(new CreateToken().TokenGenerateAdmin());
        }
        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("Welcome Admin,Visitor");
        }
    }
}
