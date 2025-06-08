using RaceStrategyManager.Domain.Models;

namespace RaceStrategyManager.Infrastructure.Contract
{
    public interface IStrategyRepository
    {
        Task SaveStrategy(Strategy strategy);
        Task SaveStrategyLog(StrategyLog strategyLog);

    }
}
