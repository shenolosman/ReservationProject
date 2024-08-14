using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.ServiceDto;
using Project.WebUI.Dtos.StaffDto;

namespace Project.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLastFourStaffListPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;

        public _DashboardLastFourStaffListPartial(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Staff/Last4Staff");

            if (responseMsg.IsSuccessStatusCode)
            {
                var jsData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast4StaffDto>>(jsData);
                return View(values);
            }
            return View();
        }
    }
}
