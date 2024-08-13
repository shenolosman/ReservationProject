using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project.EntityLayer.Concrete;
using Project.WebUI.Dtos.AppUserDto;
using System.Net.Http;

namespace Project.WebUI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous]

    public class AdminUsersController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        //private readonly UserManager<AppUser> _userManager;

        //public AdminUsersController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        public AdminUsersController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/AppUser/UserWithWorkLocationList");

            if (responseMsg.IsSuccessStatusCode)
            {
                var jsData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsData);
                return View(values);
            }
            return View();
        }
    }
}
