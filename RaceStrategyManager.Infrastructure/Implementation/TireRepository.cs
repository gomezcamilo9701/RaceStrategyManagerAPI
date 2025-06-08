using Microsoft.EntityFrameworkCore;
using RaceStrategyManager.Domain.Models;
using RaceStrategyManager.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStrategyManager.Infrastructure.Implementation
{
    public class TireRepository : ITireRepository
    {
        private readonly RaceStrategyManagerContext _context;

        public TireRepository(RaceStrategyManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Tire>> GetAll()
        {
            return await _context.Tires.ToListAsync();
        }
    }
}
