using DGNet002_Week_7_8_Task.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DGNet002_Week_7_8_Task.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public PortfolioController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<IActionResult> Portfolio()
        {
            var project = await _projectRepository.GetProjects();
            return View(project);
        }
    }
}
