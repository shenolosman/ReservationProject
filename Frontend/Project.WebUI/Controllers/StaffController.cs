﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Models.Staff;
using System.Text;

namespace Project.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("http://localhost:5292/api/Staff");

            if (responseMsg.IsSuccessStatusCode)
            {
                var jsData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff() { return View(); }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5292/api/Staff", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.DeleteAsync($"http://localhost:5292/api/Staff/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync($"http://localhost:5292/api/Staff/{id}");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData=await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMsg = await client.PutAsync("http://localhost:5292/api/Staff/",content);
            if (responseMsg.IsSuccessStatusCode)
            {
               return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
