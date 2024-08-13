using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.WorkLocation;
using System.Text;

namespace Project.WebUI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous]
    public class AdminWorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AdminWorkLocationController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/WorkLocation");
            if (responseMsg.IsSuccessStatusCode)
            {
                var JsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(JsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddWorkLocation() { return View(); }
        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(CreateWorkLocationDto model)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClient.CreateClient();
            var jsData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5292/api/WorkLocation", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.DeleteAsync($"http://localhost:5292/api/WorkLocation/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWorkLocation(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/WorkLocation/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateWorkLocationDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto model)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMsg = await client.PutAsync("http://localhost:5292/api/WorkLocation/", content);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
