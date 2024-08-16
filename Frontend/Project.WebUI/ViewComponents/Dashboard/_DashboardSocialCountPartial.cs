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

            var requestInstagram = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-api2.p.rapidapi.com/v1/info?username_or_id_or_url=o.shenol"),
                Headers =
    {
        { "x-rapidapi-key", "d7b9e0444cmsheedc6631451618ep1c1136jsn991c4383e79e" },
        { "x-rapidapi-host", "instagram-scraper-api2.p.rapidapi.com" },
    },
            };
            using var response = await client.SendAsync(requestInstagram);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            ResultInstagramDto resultInstagramDtos = JsonConvert.DeserializeObject<ResultInstagramDto>(body);
            ViewBag.InstagramFollower = resultInstagramDtos.Data.follower_count;
            ViewBag.InstagramFollowing = resultInstagramDtos.Data.following_count;

            var requestTwitter = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter-api47.p.rapidapi.com/v2/user/by-username?username=centredevils"),
                Headers =
    {
        { "x-rapidapi-key", "d7b9e0444cmsheedc6631451618ep1c1136jsn991c4383e79e" },
        { "x-rapidapi-host", "twitter-api47.p.rapidapi.com" },
    },
            };
            using (var response2 = await client.SendAsync(requestTwitter))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterDto resultTwitterDto = JsonConvert.DeserializeObject<ResultTwitterDto>(body2);

                ViewBag.TwitterFriends = resultTwitterDto.legacy.friends_count;
                ViewBag.TwitterFollower = resultTwitterDto.legacy.followers_count;
            }

            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://linkedin-data-scraper.p.rapidapi.com/person"),
                Headers =
    {
        { "x-rapidapi-key", "d7b9e0444cmsheedc6631451618ep1c1136jsn991c4383e79e" },
        { "x-rapidapi-host", "linkedin-data-scraper.p.rapidapi.com" },
    },
                Content = new StringContent("{\"link\":\"http://www.linkedin.com/in/shenol-osman/\"}")
                {
                    Headers =
        {
            ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
        }
                }
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkednDto resultLinkednDto = JsonConvert.DeserializeObject<ResultLinkednDto>(body3);

                ViewBag.LinkednFriends = resultLinkednDto.data.connections;
                ViewBag.LinkednFollower = resultLinkednDto.data.followers;
            }
            return View();
        }
    }
}
