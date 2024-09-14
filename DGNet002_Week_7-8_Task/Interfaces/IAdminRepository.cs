using DGNet002_Week_7_8_Task.Models;

namespace DGNet002_Week_7_8_Task.Interfaces
{
	public interface IAdminRepository
	{
		public Task<IEnumerable<AdminUser>> GetAdminUser();
		public Task<AdminUser> GetDetailsById(string id);
		public bool Save();
		public bool Add(AdminUser admin);
		public bool Delete(AdminUser admin);
		public bool Update(AdminUser admin);
	}
}
