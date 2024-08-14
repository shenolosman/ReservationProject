using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetsPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
