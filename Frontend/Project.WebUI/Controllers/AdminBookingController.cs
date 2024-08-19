using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.BookingDto;
using Project.WebUI.Dtos.GuestDto;
using System.Text;

namespace Project.WebUI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous]

    public class AdminBookingController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AdminBookingController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Booking");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> BookingApproved(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/Booking/BookingApproved/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> BookingDeclined(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/Booking/BookingDeclined/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> BookingWait(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/Booking/BookingWait/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> BookingUpdate(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/Booking/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookingUpdate(UpdateBookingDto model)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMsg = await client.PutAsync("http://localhost:5292/api/Booking/", content);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
