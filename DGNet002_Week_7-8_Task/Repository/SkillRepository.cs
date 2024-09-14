using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Repository
{
	public class SkillRepository : ISkillRepository
	{
		public ApplicationDbContext _context;
		public SkillRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool Add(Skill skill)
		{
			_context.Add(skill);
			return Save();
		}

		public bool Delete(Skill skill)
		{
			_context.Remove(skill);
			return Save();
		}

		public async Task<IEnumerable<Skill>> GetSkills()
		{
			return await _context.Skills.ToListAsync();
		}

		public async Task<Skill> GetSkillsById(int id)
		{
			return await _context.Skills.FindAsync(id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0;
		}

		public bool Update(Skill skill)
		{
			_context.Update(skill);
			return Save();
		}
	}
}
