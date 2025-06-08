using RaceStrategyManager.Domain.Models;

namespace RaceStrategyManager.Infrastructure.Contract
{
    public interface ITireRepository
    {
        Task<List<Tire>> GetAll();
    }
}
