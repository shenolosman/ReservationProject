using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.EntityLayer.Concrete;

namespace Project.WebUI.Controllers
{
    //[Authorize]
    [AllowAnonymous]

    public class AdminUsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminUsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var values= await _userManager.Users.ToListAsync();
            return View(values);
        }
    }
}
