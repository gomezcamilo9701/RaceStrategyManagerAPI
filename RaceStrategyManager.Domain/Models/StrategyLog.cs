namespace RaceStrategyManager.Domain.Models;

public partial class StrategyLog
{
    public int Id { get; set; }

    public int StrategyId { get; set; }

    public int PilotId { get; set; }

    public string GeneratedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string Details { get; set; } = null!;

    public virtual Pilot Pilot { get; set; } = null!;

    public virtual Strategy Strategy { get; set; } = null!;
}
