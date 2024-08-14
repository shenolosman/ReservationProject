using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.Dashboard
{
    public class _DashboardScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
