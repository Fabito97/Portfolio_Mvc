using DGNet002_Week_7_8_Task.Models;

namespace DGNet002_Week_7_8_Task.Interfaces
{
	public interface IResumeRepository
	{
		public Task<IEnumerable<Resume>> GetResumes();
		public Task<Resume> GetResumesById(int id);
		public bool Save();
		public bool Add(Resume resume);
		public bool Delete(Resume resume);
		public bool Update(Resume resume);
	}
}
