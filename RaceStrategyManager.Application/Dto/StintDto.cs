using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStrategyManager.Application.Dto
{
    public class StintDto
    {
        public int TireId { get; set; }
        public string TireType { get; set; }
        public int Laps { get; set; }
        public decimal FuelConsumption { get; set; }
    }
}
