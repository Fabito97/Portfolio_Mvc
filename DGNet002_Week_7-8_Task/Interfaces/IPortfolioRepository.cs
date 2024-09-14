using DGNet002_Week_7_8_Task.Models;

namespace DGNet002_Week_7_8_Task.Interfaces
{
    public interface IPortfolioRepository
    {
        public Task<IEnumerable<Project>> GetProjects();

    }
}
