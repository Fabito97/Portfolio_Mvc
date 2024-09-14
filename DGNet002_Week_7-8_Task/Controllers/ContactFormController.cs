using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Controllers
{
   
    public class ContactFormController : Controller
    {
		private readonly IContactFormRepository _contactFormRepository;
		public ContactFormController(IContactFormRepository contactFormRepository)
		{
			_contactFormRepository = contactFormRepository;
		}

		public async Task<IActionResult> Index()
        {
            var forms = await _contactFormRepository.GetContactForms();
            return View(forms);
        }




		public async Task<IActionResult> Delete(int id)
        {
            var form = await _contactFormRepository.GetFormsById(id);
            return View(form);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(int id)
        {
			var form = await _contactFormRepository.GetFormsById(id);

			if (form == null) 
				return NotFound();

			_contactFormRepository.Delete(form);
			return RedirectToAction("Index");
		}
    }
}
