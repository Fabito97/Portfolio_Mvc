using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Repository
{
	public class ResumeRepository : IResumeRepository
	{
		public ApplicationDbContext _context;
		public ResumeRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool Add(Resume resume)
		{
			_context.Add(resume);
			return Save();
		}

		public bool Delete(Resume resume)
		{
			_context.Remove(resume);
			return Save();
		}

		public async Task<IEnumerable<Resume>> GetResumes()
		{
			return await _context.Resumes.ToListAsync();
		}
		public async Task<Resume> GetResumesById(int id)
		{
			return await _context.Resumes.FindAsync(id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0;
		}

		public bool Update(Resume resume)
		{
			_context.Update(resume);
			return Save();
		}

	}
}
