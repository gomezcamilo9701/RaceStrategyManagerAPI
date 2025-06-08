namespace RaceStrategyManager.Application.Dto
{
    public class StrategyDto
    {
        public int Id { get; set; }

        public int PilotId { get; set; }

        public int TotalLaps { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal AveragePerformance {  get; set; }
        public decimal TotalFuelConsumption {  get; set; }
        public virtual ICollection<StintDto> Stints { get; set; } = new List<StintDto>();
    }
}
