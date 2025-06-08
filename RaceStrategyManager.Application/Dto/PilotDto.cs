namespace RaceStrategyManager.Application.Dto
{
    public class PilotDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Team { get; set; } = null!;

        public string Nationality { get; set; } = null!;
    }
}
