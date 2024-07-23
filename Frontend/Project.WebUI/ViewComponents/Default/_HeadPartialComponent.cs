using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.Default
{
    public class _HeadPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
