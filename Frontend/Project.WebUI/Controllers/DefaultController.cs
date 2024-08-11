using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.ServiceDto;
using Project.WebUI.Dtos.SubscribeDto;
using System.Text;

namespace Project.WebUI.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5292/api/Subscribe", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }

    }
}
