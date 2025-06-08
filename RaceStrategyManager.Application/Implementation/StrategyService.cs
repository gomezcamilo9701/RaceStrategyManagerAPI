using RaceStrategyManager.Application.Contract;
using RaceStrategyManager.Application.Dto;
using RaceStrategyManager.Domain.Models;
using RaceStrategyManager.Infrastructure.Contract;

namespace RaceStrategyManager.Application.Implementation
{
    public class StrategyService : IStrategyService
    {
        private readonly IStrategyRepository _strategyRepository;
        private readonly ITireRepository _tireRepository;

        public StrategyService(IStrategyRepository strategyRepository, ITireRepository tireRepository)
        {
            _strategyRepository = strategyRepository;
            _tireRepository = tireRepository;
        }

        private void GenerateCombination(int laps, List<Tire> tires, List<Stint> stints, List<Strategy> strategies)
        {
            if(laps == 0)
            {
                strategies.Add(new Strategy
                {
                    Stints = new List<Stint>(stints),
                    TotalLaps = stints.Sum(x => x.Laps)
                });
                return;
            }

            foreach(var tire in tires)
            {
                if(tire.EstimatedLaps <= laps)
                {
                    stints.Add(new Stint
                    {
                        Tire = tire,
                        TireId = tire.Id,
                        Laps = tire.EstimatedLaps,
                        CreatedBy = "FromApplicationLayer",
                        CreatedAt = DateTime.UtcNow,
                    });
                    GenerateCombination(laps - tire.EstimatedLaps, tires, stints, strategies);
                    stints.RemoveAt(stints.Count - 1);
                }
            }
        }

        public async Task<List<StrategyDto>> GetOptimalStrategy(int maxLaps, int pilotId)
        {
            if (maxLaps <= 0) throw new ArgumentException("maxLaps must be higher than 0");
            if (pilotId <= 0) throw new ArgumentException("You hace to provude a pilotId");

            var tires = await _tireRepository.GetAll();
            var strategies = new List<Strategy>();
            var stint = new List<Stint>();

            GenerateCombination(maxLaps, tires, stint, strategies);

            var orderStrategies = strategies
                .OrderBy(s => s.Stints.Count)
                .ThenByDescending(x => x.AveragePerformance)
                .ToList();

            var strategyDto = new List<StrategyDto>();

            foreach (var strategy in orderStrategies)
            {
                strategy.PilotId = pilotId;
                strategy.CreatedAt = DateTime.UtcNow;
                strategy.CreatedBy = "System";
                await _strategyRepository.SaveStrategy(strategy);

                var log = new StrategyLog
                {
                    StrategyId = strategy.Id,
                    PilotId = pilotId,
                    GeneratedBy = "Admin",
                    CreatedAt = DateTime.UtcNow,
                    Details = $"Strategy with {strategy.Stints.Count} stints for {maxLaps}"
                };
                await _strategyRepository.SaveStrategyLog(log);

                strategyDto.Add(new StrategyDto
                {
                    Id = strategy.Id,
                    PilotId = strategy.PilotId,
                    TotalLaps = strategy.TotalLaps,
                    AveragePerformance = strategy.AveragePerformance,
                    TotalFuelConsumption = strategy.TotalFuelConsumption,
                    Stints = strategy.Stints.Select(s => new StintDto
                    {
                        TireId = s.TireId,
                        TireType = s.Tire.Type,
                        Laps = s.Laps,
                        FuelConsumption = s.FuelConsumption
                    }).ToList()
                });
            }
            return strategyDto;
        }

    }
}
