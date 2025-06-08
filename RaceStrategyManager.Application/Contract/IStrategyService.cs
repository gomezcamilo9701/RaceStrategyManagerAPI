using RaceStrategyManager.Application.Dto;

namespace RaceStrategyManager.Application.Contract
{
    public interface IStrategyService
    {
        Task<List<StrategyDto>> GetOptimalStrategy(int maxLaps, int pilotId);
    }
}
