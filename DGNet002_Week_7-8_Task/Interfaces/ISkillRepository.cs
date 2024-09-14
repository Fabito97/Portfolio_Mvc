using DGNet002_Week_7_8_Task.Models;

namespace DGNet002_Week_7_8_Task.Interfaces
{
	public interface ISkillRepository
	{
		public Task<IEnumerable<Skill>> GetSkills();
		public Task<Skill> GetSkillsById(int id);
		public bool Save();
		public bool Add(Skill skill);
		public bool Delete(Skill skill);
		public bool Update(Skill skill);
	}
}
