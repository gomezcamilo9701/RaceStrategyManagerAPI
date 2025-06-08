using System.ComponentModel.DataAnnotations.Schema;

namespace RaceStrategyManager.Domain.Models;

public partial class Stint
{
    public int Id { get; set; }

    public int StrategyId { get; set; }

    public int TireId { get; set; }

    public int Laps { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? ModifiedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Strategy Strategy { get; set; } = null!;

    public virtual Tire Tire { get; set; } = null!;

    [NotMapped]
    public decimal FuelConsumption => Tire != null ? Laps * Tire.FuelConsumptionPerLap : 0;
}
