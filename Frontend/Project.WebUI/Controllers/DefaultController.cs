﻿using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
