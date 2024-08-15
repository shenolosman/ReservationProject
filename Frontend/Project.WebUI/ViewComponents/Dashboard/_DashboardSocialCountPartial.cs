using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.DashboardDto.FollowerDto;

namespace Project.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSocialCountPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClient;

        public _DashboardSocialCountPartial(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-api2.p.rapidapi.com/v1/info?username_or_id_or_url=o.shenol"),
                Headers =
    {
        { "x-rapidapi-key", "d7b9e0444cmsheedc6631451618ep1c1136jsn991c4383e79e" },
        { "x-rapidapi-host", "instagram-scraper-api2.p.rapidapi.com" },
    },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            ResultInstagramDto resultInstagramDtos = JsonConvert.DeserializeObject<ResultInstagramDto>(body);
            ViewBag.InstagramFollower = resultInstagramDtos.Data.follower_count;
            ViewBag.InstagramFollowing = resultInstagramDtos.Data.following_count;

            return View();
        }
    }
}
