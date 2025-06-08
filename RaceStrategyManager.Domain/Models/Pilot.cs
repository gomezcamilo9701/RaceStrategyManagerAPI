namespace RaceStrategyManager.Domain.Models;

public partial class Pilot
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Team { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? ModifiedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Strategy> Strategies { get; set; } = new List<Strategy>();

    public virtual ICollection<StrategyLog> StrategyLogs { get; set; } = new List<StrategyLog>();
}
