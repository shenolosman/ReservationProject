using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.GuestDto;
using Project.WebUI.Dtos.GuestDto;
using System.Net.Http;
using System.Text;

namespace Project.WebUI.Controllers
{
    public class AdminGuestController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AdminGuestController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var client=_httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Guest");
            if(responseMsg.IsSuccessStatusCode)
            {
                var JsonData = await responseMsg.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<ResultGuestDto>>(JsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddGuest() { return View(); }
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto model)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClient.CreateClient();
            var jsData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5292/api/Guest", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.DeleteAsync($"http://localhost:5292/api/Guest/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/Guest/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto model)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMsg = await client.PutAsync("http://localhost:5292/api/Guest/", content);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
