using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    [AllowAnonymous]

    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
