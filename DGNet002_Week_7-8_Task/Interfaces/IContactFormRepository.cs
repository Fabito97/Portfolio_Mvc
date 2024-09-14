using DGNet002_Week_7_8_Task.Models;

namespace DGNet002_Week_7_8_Task.Interfaces
{
	public interface IContactFormRepository
	{
		public Task<IEnumerable<ContactForm>> GetContactForms();		
		public Task<ContactForm> GetFormsById(int id);		
		public bool Delete(ContactForm form);
		public bool Add(ContactForm form);
		public bool Save();

	}
}
