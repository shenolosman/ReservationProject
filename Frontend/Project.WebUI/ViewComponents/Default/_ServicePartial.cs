using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.RoomDto;
using Project.WebUI.Dtos.ServiceDto;

namespace Project.WebUI.ViewComponents.Default
{
    public class _ServicePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServicePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Service");

            if (responseMsg.IsSuccessStatusCode)
            {
                var jsData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsData);
                return View(values);
            }
            return View();
        }
    }
}
