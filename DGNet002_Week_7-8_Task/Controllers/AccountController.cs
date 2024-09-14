using DGNet002_Week_7_8_Task.Models;
using DGNet002_Week_7_8_Task.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace DGNet002_Week_7_8_Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;
        private readonly SignInManager<AdminUser> _signInManager;
        public AccountController(UserManager<AdminUser> userManager, SignInManager<AdminUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid) return View(loginView);

            var adminUser = new AdminUser();

            adminUser.Email = loginView.Email;
            adminUser.PasswordHash = loginView.Password;

            var user = await _userManager.FindByEmailAsync(adminUser.Email);

            if (user != null)
            {              
                var result = await _signInManager.PasswordSignInAsync(user, adminUser.PasswordHash, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginView);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
