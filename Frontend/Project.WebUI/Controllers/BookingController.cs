using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.BookingDto;
using System.Text;

namespace Project.WebUI.Controllers
{
    [AllowAnonymous]

    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public BookingController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto model)
        {
            model.Status = "Waiting Approval";

            try
            {
                var client = _httpClient.CreateClient();

                // Ensure date formats are correct
                model.Checkin = model.Checkin.Date;
                model.Checkout = model.Checkout.Date;

                var jsonData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5292/api/Booking", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    // Log the error response for further inspection
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to add booking: {response.StatusCode}, {response.ReasonPhrase}, {errorContent}");
                    ModelState.AddModelError("", "Failed to add booking. Please check your input and try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Exception occurred while adding booking.");
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
            }

            return View(model);
        }
    }
}
