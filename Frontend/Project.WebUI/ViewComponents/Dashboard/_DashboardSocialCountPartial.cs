using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}
