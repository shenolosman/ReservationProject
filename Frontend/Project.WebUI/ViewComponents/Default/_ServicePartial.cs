using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.Default
{
    public class _ServicePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
