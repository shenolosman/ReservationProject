﻿using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
