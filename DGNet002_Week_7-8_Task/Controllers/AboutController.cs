using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGNet002_Week_7_8_Task.Controllers
{
    public class AboutController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        public AboutController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IActionResult> About()
        {
            IEnumerable<Skill> skills = await _skillRepository.GetSkills();
            return View(skills);
        }
     
    }
}
