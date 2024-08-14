using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.BookingDto;

namespace Project.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast6BookingPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;

        public _DashboardLast6BookingPartial(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Booking/Last6Booking");

            if (responseMsg.IsSuccessStatusCode)
            {
                var jsData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast6BookingDto>>(jsData);
                return View(values);
            }
            return View();
        }
    }
}
