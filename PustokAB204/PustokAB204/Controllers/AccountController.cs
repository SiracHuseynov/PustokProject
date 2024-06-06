using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PustokAB204.Core.Models;
using PustokAB204.ViewModels;

namespace PustokAB204.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterVm memberRegisterVm)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser user = null;
            user = await _userManager.FindByNameAsync(memberRegisterVm.Username);

            if (user is not null)
            {
                ModelState.AddModelError("UserName", "UserName already exist!");
                return View();
            }

            user = await _userManager.FindByEmailAsync(memberRegisterVm.Email);

            if (user is not null)
            {
                ModelState.AddModelError("Email", "Email already exist!");
                return View();
            }

            user = new AppUser()
            {
                FullName = memberRegisterVm.FullName,
                UserName = memberRegisterVm.Username,
                Email = memberRegisterVm.Email,
            };

            var result = await _userManager.CreateAsync(user, memberRegisterVm.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                    return View();
                }
            }

            await _userManager.AddToRoleAsync(user, "Member");
            return RedirectToAction("Login");
        }
    }
}
