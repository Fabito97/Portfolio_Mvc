using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Repository
{
	public class AdminRepository : IAdminRepository
	{
		public ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context)
        {
			_context = context;
		}

		public bool Add(AdminUser admin)
		{
			_context.Add(admin);
			return Save();
		}

		public bool Delete(AdminUser admin)
		{
			_context.Remove(admin);
			return Save();
		}		

		public async Task<IEnumerable<AdminUser>> GetAdminUser()
		{
			return await _context.Users.ToListAsync();			
		}

		public async Task<AdminUser> GetDetailsById(string id)
		{
			return await _context.Users.FindAsync(id);
		}

		public bool Save()
		{
			try
			{
				var saved = _context.SaveChanges();
				return saved > 0;
			}
			catch (Exception ex)
			{
				throw;
			}
			
		}

		public bool Update(AdminUser admin)
		{
			var existingAdminUser = _context.Users.Find(admin.Id);

			if (existingAdminUser != null)
			{
				_context.Entry(existingAdminUser).CurrentValues.SetValues(admin);
				//_context.Update(admin);
				return Save();

			}
			throw new InvalidOperationException("The entity to be updated was not found.");
		}
	}
}
