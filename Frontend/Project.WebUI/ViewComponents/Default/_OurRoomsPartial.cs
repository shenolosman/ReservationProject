using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.Default
{
    public class _OurRoomsPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
