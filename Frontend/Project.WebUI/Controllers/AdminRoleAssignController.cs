using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.EntityLayer.Concrete;
using Project.WebUI.Models.Role;

namespace Project.WebUI.Controllers
{
    public class AdminRoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.Users.ToListAsync();
            return View(values);
        }
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            TempData["userid"] = user.Id;
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> assignments = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = role.Id;
                model.RoleName = role.Name;
                model.RoleExist = userRoles.Contains(role.Name);
                assignments.Add(model);
            }
            return View(assignments);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int)TempData["userid"];
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            foreach (var role in model)
            {
                if (role.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
