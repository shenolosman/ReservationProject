using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.BookingDto;

namespace Project.WebUI.Controllers
{
    [Authorize]

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

        public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto model)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData);
            var responseMsg = await client.PutAsync("http://localhost:5292/api/Booking/UpdateReservationStatus", content);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> ApprovedReservationWithId(ApprovedReservationDto model)
        {
            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData);
            var responseMsg = await client.PutAsync("http://localhost:5292/api/Booking/UpdateReservationStatusWithId", content);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
