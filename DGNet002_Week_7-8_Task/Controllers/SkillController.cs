using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Controllers
{

    public class SkillController : Controller
    {
		private readonly ISkillRepository _skillRepository;
		public SkillController(ISkillRepository skillRepository)
		{
			_skillRepository = skillRepository;
		}

		public async Task<IActionResult> Index()
        {
            IEnumerable<Skill> skills = await _skillRepository.GetSkills();
            return View(skills);
        }

        public IActionResult Create()
        {
            return View();

        }

		[HttpPost]
		public IActionResult Create(Skill skill)
		{

			if (ModelState.IsValid)
			{
				_skillRepository.Add(skill);

				return RedirectToAction("Index");
			}
			return View(skill);
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (id == null) return NotFound();

			var skill = await _skillRepository.GetSkillsById(id);

			if (skill == null) return NotFound();

			return View(skill);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Skill skill)
		{

			if (ModelState.IsValid)
			{
				_skillRepository.Update(skill);

				return RedirectToAction("Index");
			}
			return View(skill);
		}
		public async Task<IActionResult> Delete(int id)
		{
			if (id == null) return NotFound();

			var skill = await _skillRepository.GetSkillsById(id);

			if (skill == null) return NotFound();

			return View(skill);
		}

		[HttpPost]
		[ActionName("Delete")]
		public async Task<IActionResult> DeletePOST(int id)
		{
			var skill = await _skillRepository.GetSkillsById(id);

			if (skill == null) 
				return NotFound();

			_skillRepository.Delete(skill);
			return RedirectToAction("Index");

		}
	}
}
