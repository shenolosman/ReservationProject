using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.AboutUsDto;
using Project.WebUI.Dtos.RoomDto;

namespace Project.WebUI.ViewComponents.Default
{
    public class _OurRoomsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OurRoomsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
