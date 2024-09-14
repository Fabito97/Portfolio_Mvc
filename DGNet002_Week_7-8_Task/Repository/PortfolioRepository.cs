using DGNet002_Week_7_8_Task.Data;
using DGNet002_Week_7_8_Task.Interfaces;
using DGNet002_Week_7_8_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
           return await _context.Projects.ToListAsync();
        }
    }
}
