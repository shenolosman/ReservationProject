using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Project.EntityLayer.Concrete;
using Project.WebUI.Dtos.ContactDto;
using Project.WebUI.Dtos.ContactMessageCategory;
using System.Text;

namespace Project.WebUI.Controllers
{
    [AllowAnonymous]

    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public ContactController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/ContactMessageCategory");

            var jsonData = await responseMsg.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactMessageCategoryDto>>(jsonData);

            List<SelectListItem> selectListItems = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.SubjectField,
                                                        Value = x.ContactMessageCategoryId.ToString()
                                                    }).ToList();

            ViewBag.SelectList= selectListItems;

            return View();

        }
        public IActionResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto model)
        {
            model.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            var client = _httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5292/api/Contact", content);
            return RedirectToAction("Index");
        }

    }
}
