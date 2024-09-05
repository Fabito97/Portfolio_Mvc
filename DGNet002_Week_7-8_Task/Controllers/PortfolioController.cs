using Microsoft.AspNetCore.Mvc;

namespace DGNet002_Week_7_8_Task.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Portfolio()
        {
            return View();
        }
    }
}
