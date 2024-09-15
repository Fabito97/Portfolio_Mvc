using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using DGNet002_Week_7_8_Task.Services;
using DGNet002_Week_7_8_Task.ViewModel;
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
			var resumeModel = await _resumeRepository.GetResumesSections();

			if (resumeModel == null)
				resumeModel = new IndexResumeViewModel();

            return View(resumeModel);
        }

        public IActionResult Create()
        {
			var resumeModel = new CreateResumeViewModel();
            return View(resumeModel);
        }

		[HttpPost]
		public IActionResult Create(CreateResumeViewModel resumeModel)
		{
			if (resumeModel != null)
			{
				_resumeRepository.AddResume(resumeModel);

				return RedirectToAction("Create");
			}
			return View(resumeModel);
		}

		public async Task<IActionResult> Edit()
		{
			var resumeModel = await _resumeRepository.GetResumesSections();

			if (resumeModel == null)
				return NotFound();

			return View(resumeModel);
		}

		[HttpPost]
		public IActionResult Edit(IndexResumeViewModel resumeModel)
		{			

			if (resumeModel != null)
			{				
				_resumeRepository.UpdateResume(resumeModel);

				return RedirectToAction("Index");
			}
			return View(resumeModel);
		}



		/*public async Task<IActionResult> Delete(int id)
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

		}*/
	}
}
