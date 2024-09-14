using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Security.Claims;

namespace DGNet002_Week_7_8_Task.Controllers
{
    [Authorize]   
	public class AdminController : Controller
	{
        private readonly IAdminRepository _adminRepository;
        public AdminController(IAdminRepository adminRepository)
        {
			_adminRepository = adminRepository;
        }
             
        
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> Detail()
        {
            var admindetails = await _adminRepository.GetAdminUser();
            return View(admindetails);
        }                  


        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var admindetails = await _adminRepository.GetDetailsById(id);

            if (admindetails == null) return NotFound();
                      

            return View(admindetails);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPOST(AdminUser admin)
        {
            if (ModelState.IsValid)
            {                
			    _adminRepository.Update(admin);          

                return RedirectToAction("Detail");

            }
           
            return View(admin);
        }

/*        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }*/

    }
}
