using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.ContactDto;
using System.Text;

namespace Project.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public ContactController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto model)
        {
            model.Date= Convert.ToDateTime(DateTime.Now.ToShortDateString());

            var client= _httpClient.CreateClient(); 
            var jsonData= JsonConvert.SerializeObject(model);
            var content= new StringContent(jsonData,Encoding.UTF8,"application/json");
            await client.PostAsync("http://localhost:5292/api/Contact", content);
            return RedirectToAction("Index");
        }

    }
}
