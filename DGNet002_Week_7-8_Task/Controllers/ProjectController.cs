using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using DGNet002_Week_7_8_Task.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Controllers
{
  
    public class ProjectController : Controller
    {
		private readonly IProjectRepository _projectRepository;
		private readonly IPhotoService _photoService;
        private readonly ILogger<ProjectController> _logger;

		public ProjectController(IProjectRepository projectRepository, IPhotoService photoService, ILogger<ProjectController> logger)
		{
			_projectRepository = projectRepository;
			_photoService = photoService;
            _logger = logger;
		}


		public async Task<IActionResult> Index()
        {
            IEnumerable<Project> portfolios = await _projectRepository.GetProjects();
            return View(portfolios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel projectVM)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _photoService.AddPhotoAsync(projectVM.Image);

                    var project = new Project
                    {
                        Title = projectVM.Title,
                        Description = projectVM.Description,
                        Image = result.Url.ToString(),
                        ProjectLink = projectVM.ProjectLink,
                        PublicId = result.PublicId,
                    };
                    /*
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var imagePath = Path.Combine("wwwroot/Images", imageFile.FileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        project.Image = "/Images/" + imageFile.FileName;
                    }*/

                    _projectRepository.Add(project);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occurred while creating the project: ", ex);
                }
            }
            return View(projectVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();
            
            var project = await _projectRepository.GetProjectsById(id);

            if (project == null) return NotFound();

            var viewModel = new ProjectViewModel()
            {
                ProjectItemId = id,
                Title = project.Title,
                Description = project.Description,
                ProjectLink = project.ProjectLink,
                PublicId = project.PublicId,
                ProjectUrl = project.Image,
            };
            return View(viewModel);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(ProjectViewModel projectVM)
		{            
            
			if (ModelState.IsValid)
			{
				var result = await _photoService.UpdatePhotoAsync(projectVM.Image, projectVM.PublicId);

				var project = new Project
				{
                    ProjectId = projectVM.ProjectItemId,
					Title = projectVM.Title,
					Description = projectVM.Description,
					Image = result.Url.ToString(),
					ProjectLink = projectVM.ProjectLink,
                    PublicId = result.PublicId
				};
				_projectRepository.Update(project);


				return RedirectToAction("Index");
			}
			return View(projectVM);
		}
		public async Task<IActionResult> Delete(int id)
        {
			if (id == null) 
                return NotFound();

			var project = await _projectRepository.GetProjectsById(id);

			if (project == null) 
                return NotFound();

			return View(project);
		}

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var project = await _projectRepository.GetProjectsById(id);

            if (project == null) 
                return NotFound();

            if (!string.IsNullOrEmpty(project.Image))
                _photoService.DeletePhotoAsync(project.PublicId);           

			_projectRepository.Delete(project);
		    return RedirectToAction("Index");
       
        }


    }
}
