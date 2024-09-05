using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGNet002_Week_7_8_Task.Controllers
{
    public class ContactController : Controller
    {
    private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
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
                _context.contactForms.Add(contactForm);
                _context.SaveChanges();
                return RedirectToAction("About", "About");
            }
            return View();
        }

    }
}
