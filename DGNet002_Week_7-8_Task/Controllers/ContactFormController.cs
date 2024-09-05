using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGNet002_Week_7_8_Task.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ContactForm()
        {
            List<ContactForm> forms = _context.contactForms.ToList();
            return View(forms);
        }

        [HttpPost]
        public IActionResult Contact(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                _context.contactForms.Add(contactForm);
                _context.SaveChanges();
                return RedirectToAction("About", "About"); 
            }
            return View();
        }
    }
}
