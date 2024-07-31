﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.BookingDto;

namespace Project.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public BookingAdminController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            var responseMsg= await client.GetAsync("http://localhost:5292/api/Booking");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData= await responseMsg.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
