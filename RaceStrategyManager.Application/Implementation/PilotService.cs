using RaceStrategyManager.Application.Contract;
using RaceStrategyManager.Application.Dto;
using RaceStrategyManager.Domain.Models;
using RaceStrategyManager.Infrastructure.Contract;

namespace RaceStrategyManager.Application.Implementation
{
    public class PilotService : IPilotService
    {
        private readonly IPilotRepository _pilotRepository;

        public PilotService(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task<List<PilotDto>> GetAllPilotsAsync()
        {
            var pilots = await _pilotRepository.GetAllPilotsAsync();
            var pilotsDto = new List<PilotDto>();

            foreach (var pilot in pilots)
            {
                var pilotDes = AutoMapperConfig.GetMapper<Pilot, PilotDto>().Map<PilotDto>(pilot);
                pilotsDto.Add(pilotDes);
            }
            return pilotsDto;
        }
    }
}
