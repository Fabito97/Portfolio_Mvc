using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Controllers
{

    public class ResumeController : Controller
    {
		private readonly IResumeRepository _resumeRepository;
		public ResumeController(IResumeRepository resumeRepository)
		{
			_resumeRepository = resumeRepository;
		}

		public async Task<IActionResult> Index()
        {
            IEnumerable<Resume> resumes = await _resumeRepository.GetResumes();
            return View(resumes);
        }

        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Create(Resume resume)
		{			
			if (ModelState.IsValid)
			{
				_resumeRepository.Add(resume);

				return RedirectToAction("Create");
			}
			return View(resume);
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (id == null) return NotFound();

			var resume = await _resumeRepository.GetResumesById(id);

			if (resume == null) return NotFound();

			return View(resume);
		}

		[HttpPost]
		public IActionResult Edit(Resume resume)
		{			

			if (ModelState.IsValid)
			{				
				_resumeRepository.Update(resume);

				return RedirectToAction("Create");
			}
			return View(resume);
		}
		public async Task<IActionResult> Delete(int id)
		{
			if (id == null) return NotFound();

			var project = await _resumeRepository.GetResumesById(id);

			if (project == null) return NotFound();

			return View(project);
		}

		[HttpPost]
		[ActionName("Delete")]
		public async Task<IActionResult> DeletePOST(int id)
		{
			var resume = await _resumeRepository.GetResumesById(id);

			if (resume == null) 
				return NotFound();

			_resumeRepository.Delete(resume);
			return RedirectToAction("Index");

		}
	}
}
