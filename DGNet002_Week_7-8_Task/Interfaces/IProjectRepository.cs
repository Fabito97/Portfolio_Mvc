using DGNet002_Week_7_8_Task.Models;
using Microsoft.Build.Evaluation;

namespace DGNet002_Week_7_8_Task.Interfaces
{
	public interface IProjectRepository
	{
		public Task<IEnumerable<Models.Project>> GetProjects();
		public Task<Models.Project> GetProjectsById(int id);
		public bool Save();
		public bool Add(Models.Project project);
		public bool Delete(Models.Project project);
		public bool Update(Models.Project project);
	}
}
