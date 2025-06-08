using Microsoft.EntityFrameworkCore;
using RaceStrategyManager.Domain.Models;
using RaceStrategyManager.Infrastructure.Contract;

namespace RaceStrategyManager.Infrastructure.Implementation
{
    public class PilotRepository : IPilotRepository
    {
        private RaceStrategyManagerContext _context;

        public PilotRepository(RaceStrategyManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Pilot>> GetAllPilotsAsync()
        {
            return await _context.Pilots.ToListAsync();
        }
    }
}
