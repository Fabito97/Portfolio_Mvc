using DGNet002_Week_7_8_Task.Models;
using DGNet002_Week_7_8_Task.ViewModel;

namespace DGNet002_Week_7_8_Task.Interfaces
{
	public interface IResumeRepository
	{
		public Task<IndexResumeViewModel> GetResumesSections();
		/*public Task<Resume> GetResumesById(int id);
		public bool Save();
		public bool Add(Resume resume);
		public bool Delete(Resume resume);*/
		public Task UpdateResume(IndexResumeViewModel resume);
		public Task AddResume(CreateResumeViewModel resume);
	}
}
