using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Project.WebUI.Controllers
{
    [Authorize]
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
        public IActionResult ImageUpload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            using var byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            using var multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            var client = _httpClient.CreateClient();

            try
            {
                var response = await client.PostAsync("http://localhost:5292/api/FileImage/UploadImage", multipartFormDataContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }

            return View(nameof(Index));

        }
        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            using var byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            using var multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            var client = _httpClient.CreateClient();

            try
            {
                var response = await client.PostAsync("http://localhost:5292/api/FileImage/UploadFile", multipartFormDataContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }

            return View(nameof(Index));

        }
    }
}
