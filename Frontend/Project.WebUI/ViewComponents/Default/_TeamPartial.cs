using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.StaffDto;

namespace Project.WebUI.ViewComponents.Default
{
    public class _TeamPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TeamPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Staff");

            if (responseMsg.IsSuccessStatusCode)
            {
                var jsData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsData);
                return View(values);
            }
            return View();
        }
    }
}
