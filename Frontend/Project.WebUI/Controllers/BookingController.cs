using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
