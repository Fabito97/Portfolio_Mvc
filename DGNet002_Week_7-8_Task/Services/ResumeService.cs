using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using DGNet002_Week_7_8_Task.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Services
{
    public class IResumeService : IResumeRepository
    {
        private readonly ApplicationDbContext _context;

        public IResumeService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IndexResumeViewModel> GetResumesSections()
        {
            return new IndexResumeViewModel()
            {
                Resumes = await _context.Resumes.FirstOrDefaultAsync(),
                Educations = await _context.Educations.ToListAsync(),
                WorkExperiences = await _context.Experiences.ToListAsync()
            };
        }

        public async Task UpdateResume(IndexResumeViewModel resumeVM)
        {
                    
			_context.Entry(resumeVM.Resumes).State = EntityState.Detached;
                _context.Attach(resumeVM.Resumes);
			_context.Entry(resumeVM.Resumes).State = EntityState.Modified;



			foreach (var item in resumeVM.Educations)
            {
                _context.Entry(item).State = EntityState.Detached;
                _context.Attach(item);
                _context.Entry(item).State = EntityState.Modified;

                Console.WriteLine();


            }
			foreach (var item in resumeVM.WorkExperiences)
            {
				_context.Entry(item).State = EntityState.Detached;
				_context.Attach(item);

				_context.Entry(item).State = EntityState.Modified;

            }

            await _context.SaveChangesAsync();
            
        }
        public async Task AddResume(CreateResumeViewModel resumeVM)
        {
               if (resumeVM.Resumes != null)          
              _context.Resumes.Add(resumeVM.Resumes);

			if (resumeVM.Educations != null)
				_context.Educations.Add(resumeVM.Educations);

			if (resumeVM.Educations != null)
				_context.Experiences.Add(resumeVM.WorkExperiences);

            await _context.SaveChangesAsync();
            
        }

    
    }
}
