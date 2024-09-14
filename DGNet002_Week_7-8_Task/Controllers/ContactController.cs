using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGNet002_Week_7_8_Task.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactFormRepository _contactFormRepository;
        public ContactController(IContactFormRepository contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }

        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                _contactFormRepository.Add(contactForm);
                /*ViewBag.FormSubmitted = true;
                TempData["success"] = "Form Submitted Successfully";*/
                return RedirectToAction("Contact", "Contact");
            }
            return View(contactForm);
        }

    }
}
