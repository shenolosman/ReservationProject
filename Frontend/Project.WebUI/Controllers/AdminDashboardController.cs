using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous]
    public class AdminDashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AdminDashboardController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
