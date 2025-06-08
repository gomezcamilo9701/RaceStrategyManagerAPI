namespace RaceStrategyManager.Domain.Models;

public partial class Tire
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int EstimatedLaps { get; set; }

    public decimal FuelConsumptionPerLap { get; set; }

    public int Performance { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? ModifiedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Stint> Stints { get; set; } = new List<Stint>();
}
