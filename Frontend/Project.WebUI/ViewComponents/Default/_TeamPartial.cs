using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.Default
{
    public class _TeamPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
