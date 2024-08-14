using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.Dashboard
{
    public class _DashboardHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
