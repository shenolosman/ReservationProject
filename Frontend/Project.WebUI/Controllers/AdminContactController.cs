using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.ContactDto;
using Project.WebUI.Dtos.GuestDto;
using Project.WebUI.Dtos.StaffDto;
using System.Net.Http;
using System.Text;

namespace Project.WebUI.Controllers
{
    [Authorize]

    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AdminContactController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Contact");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInboxContactDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarCategoryAdminContactPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult AddSendMessage() { return View(); }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderMail = "admin@gmail.com";
            model.SenderName = "Admin";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            var client = _httpClient.CreateClient();
            var jsData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5292/api/SendMessage", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/SendMessage");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        private async Task<IActionResult> GetMessageDetailsAsync<T>(string url)
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync(url);
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<T>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsReceiver(int id)
        {
            return await GetMessageDetailsAsync<GetMessageContactByIdDto>($"http://localhost:5292/api/Contact/{id}");
        }
        public async Task<IActionResult> MessageDetailsSender(int id)
        {
            return await GetMessageDetailsAsync<GetMessageSendMessageByIdDto>($"http://localhost:5292/api/SendMessage/{id}");
        }

    }
}
