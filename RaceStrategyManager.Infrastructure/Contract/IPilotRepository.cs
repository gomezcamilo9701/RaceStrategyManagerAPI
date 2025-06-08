using RaceStrategyManager.Domain.Models;

namespace RaceStrategyManager.Infrastructure.Contract
{
    public interface IPilotRepository
    {
        Task<List<Pilot>> GetAllPilotsAsync();
    }
}
