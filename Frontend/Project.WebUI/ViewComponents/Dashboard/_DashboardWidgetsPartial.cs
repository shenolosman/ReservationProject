using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.AboutUsDto;

namespace Project.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;

        public _DashboardWidgetsPartial(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/DashboardWidgets/StaffCount");
            var staffCountData = await responseMsg.Content.ReadAsStringAsync();
            TempData["StaffCount"] = staffCountData;

            var responseMsg2 = await client.GetAsync("http://localhost:5292/api/DashboardWidgets/BookingCount");
            var bookingCountData = await responseMsg2.Content.ReadAsStringAsync();
            TempData["BookingCount"] = bookingCountData;

            var responseMsg3 = await client.GetAsync("http://localhost:5292/api/DashboardWidgets/GuestCount");
            var guestCountData = await responseMsg3.Content.ReadAsStringAsync();
            TempData["GuestCount"] = guestCountData;

            var responseMsg4 = await client.GetAsync("http://localhost:5292/api/DashboardWidgets/RoomCount");
            var roomCountData = await responseMsg4.Content.ReadAsStringAsync();
            TempData["RoomCount"] = roomCountData;

            return View();
        }
    }
}
