using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.RoomDto;
using System.Text;

namespace Project.WebUI.Controllers
{
    [Authorize]

    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public AdminRoomController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Room");

            if (responseMsg.IsSuccessStatusCode)
            {
                var jsData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddRoom() { return View(); }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto model)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5292/api/Room", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.DeleteAsync($"http://localhost:5292/api/Room/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/Room/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRoomDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto model)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMsg = await client.PutAsync("http://localhost:5292/api/Room/", content);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
