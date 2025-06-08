using RaceStrategyManager.Application.Dto;

namespace RaceStrategyManager.Application.Contract
{
    public interface IPilotService
    {
        Task<List<PilotDto>> GetAllPilotsAsync();
    }
}
