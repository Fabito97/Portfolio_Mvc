using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Repository
{
	public class ProjectRepository : IProjectRepository
	{
		public ApplicationDbContext _context;
		public ProjectRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool Add(Models.Project project)
		{
			_context.Add(project);
			return Save();
		}

		public bool Delete(Models.Project project)
		{
			_context.Remove(project);
			return Save();
		}

		public async Task<IEnumerable<Models.Project>> GetProjects()
		{
			return await _context.Projects.ToListAsync();
		}

		public async Task<Models.Project> GetProjectsById(int id)
		{
			return await _context.Projects.FindAsync(id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0;
		}

		public bool Update(Models.Project project)
		{
			_context.Update(project);
			return Save();
		}
	}
}
