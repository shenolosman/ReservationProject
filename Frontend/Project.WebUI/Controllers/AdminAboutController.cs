using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.AboutUsDto;
using System.Text;

namespace Project.WebUI.Controllers
{
    [Authorize]

    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AdminAboutController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/AboutUs");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutUsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAboutUs(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/AboutUs/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutUsDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutUs(UpdateAboutUsDto model)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMsg = await client.PutAsync("http://localhost:5292/api/AboutUs/", content);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
