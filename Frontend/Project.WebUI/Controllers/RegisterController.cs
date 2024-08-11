using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.EntityLayer.Concrete;
using Project.WebUI.Dtos.AppUserDto;

namespace Project.WebUI.Controllers
{
    [AllowAnonymous]

    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateAppUserDto model)
        {
            if (!ModelState.IsValid) return View();

            var appUser= new AppUser()
            {
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                UserName= model.UserName
            };
            var result = await _userManager.CreateAsync(appUser,model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
