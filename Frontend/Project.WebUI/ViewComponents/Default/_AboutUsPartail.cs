using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.Default
{
    public class _AboutUsPartail : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
