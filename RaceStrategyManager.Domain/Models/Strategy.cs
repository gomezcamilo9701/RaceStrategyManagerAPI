using System.ComponentModel.DataAnnotations.Schema;

namespace RaceStrategyManager.Domain.Models;

public partial class Strategy
{
    public int Id { get; set; }

    public int PilotId { get; set; }

    public int TotalLaps { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? ModifiedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Pilot Pilot { get; set; } = null!;

    public virtual ICollection<Stint> Stints { get; set; } = new List<Stint>();

    public virtual ICollection<StrategyLog> StrategyLogs { get; set; } = new List<StrategyLog>();
    [NotMapped]
    public decimal AveragePerformance => (decimal)(Stints.Any() ? Stints.Average(x => x.Tire.Performance) : 0);
    [NotMapped]
    public decimal TotalFuelConsumption => Stints.Sum(x => x.FuelConsumption);
}
