using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.ServiceDto;
using Project.WebUI.Dtos.TestimonialDto;

namespace Project.WebUI.ViewComponents.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Testimonial");

            if (responseMsg.IsSuccessStatusCode)
            {
                var jsData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsData);
                return View(values);
            }
            return View();
        }
    }
}
