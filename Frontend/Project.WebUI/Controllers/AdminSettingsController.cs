using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.EntityLayer.Concrete;
using Project.WebUI.Models.Setting;

namespace Project.WebUI.Controllers
{
    public class AdminSettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminSettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = user.Name;
            model.Email = user.Email;
            model.Surname = user.Surname;
            model.Username = user.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            if (model.Password != model.ConfirmPassword) return View(model);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Login");

        }
    }
}
