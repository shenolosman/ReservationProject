using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Project.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AdminImageFileController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var client = _httpClient.CreateClient();
            await client.PostAsync("http://localhost:5192/api/FileImage", multipartFormDataContent);

            return View();
        }
    }
}
