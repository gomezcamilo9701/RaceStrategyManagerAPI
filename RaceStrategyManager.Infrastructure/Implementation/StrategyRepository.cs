using RaceStrategyManager.Domain.Models;
using RaceStrategyManager.Infrastructure.Contract;

namespace RaceStrategyManager.Infrastructure.Implementation
{
    public class StrategyRepository : IStrategyRepository
    {
        private readonly RaceStrategyManagerContext _context;

        public StrategyRepository(RaceStrategyManagerContext context)
        {
            _context = context;
        }

        public async Task SaveStrategy(Strategy strategy)
        {
            await _context.AddAsync(strategy);
            await _context.SaveChangesAsync();
        }
        public async Task SaveStrategyLog(StrategyLog strategyLog)
        {
            await _context.AddAsync(strategyLog);
            await _context.SaveChangesAsync();
        }
    }
}
