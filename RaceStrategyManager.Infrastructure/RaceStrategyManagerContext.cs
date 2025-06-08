using Microsoft.EntityFrameworkCore;
using RaceStrategyManager.Domain.Models;

namespace RaceStrategyManager.Infrastructure;

public partial class RaceStrategyManagerContext : DbContext
{
    public RaceStrategyManagerContext()
    {
    }

    public RaceStrategyManagerContext(DbContextOptions<RaceStrategyManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pilot> Pilots { get; set; }

    public virtual DbSet<Stint> Stints { get; set; }

    public virtual DbSet<Strategy> Strategies { get; set; }

    public virtual DbSet<StrategyLog> StrategyLogs { get; set; }

    public virtual DbSet<Tire> Tires { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=RaceStrategyManager;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pilot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pilots__3214EC07EB7DECB1");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Nationality).HasMaxLength(50);
            entity.Property(e => e.Team).HasMaxLength(70);
        });

        modelBuilder.Entity<Stint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stints__3214EC078A451C7F");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);

            entity.HasOne(d => d.Strategy).WithMany(p => p.Stints)
                .HasForeignKey(d => d.StrategyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stints__Strategy__48CFD27E");

            entity.HasOne(d => d.Tire).WithMany(p => p.Stints)
                .HasForeignKey(d => d.TireId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stints__TireId__49C3F6B7");
        });

        modelBuilder.Entity<Strategy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Strategi__3214EC0773C144E7");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);

            entity.HasOne(d => d.Pilot).WithMany(p => p.Strategies)
                .HasForeignKey(d => d.PilotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Strategie__Pilot__45F365D3");
        });

        modelBuilder.Entity<StrategyLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Strategy__3214EC0773FA3E6F");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.GeneratedBy).HasMaxLength(100);

            entity.HasOne(d => d.Pilot).WithMany(p => p.StrategyLogs)
                .HasForeignKey(d => d.PilotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StrategyL__Pilot__4D94879B");

            entity.HasOne(d => d.Strategy).WithMany(p => p.StrategyLogs)
                .HasForeignKey(d => d.StrategyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StrategyL__Strat__4CA06362");
        });

        modelBuilder.Entity<Tire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tires__3214EC0754179C5C");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.FuelConsumptionPerLap).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
