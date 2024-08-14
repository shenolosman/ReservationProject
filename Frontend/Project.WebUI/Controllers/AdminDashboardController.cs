using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class AdminDashboardController : Controller
    {
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
