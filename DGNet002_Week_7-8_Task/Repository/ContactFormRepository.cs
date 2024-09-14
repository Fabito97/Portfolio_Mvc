using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Repository
{
	public class ContactFormRepository : IContactFormRepository
	{
		public ApplicationDbContext _context;
		public ContactFormRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool Add(ContactForm form)
		{
			_context.Add(form);
			return Save();
		}

		public bool Delete(ContactForm form)
		{
			_context.Add(form);
			return Save();
		}

		public async Task<IEnumerable<ContactForm>> GetContactForms()
		{
			return await _context.ContactForms.ToListAsync();
		}

		public async Task<ContactForm> GetFormsById(int id)
		{
			return await _context.ContactForms.FindAsync(id);
		}


		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0;
		}
	}
}
