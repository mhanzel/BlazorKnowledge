using Core.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Server.Shared.DataModelSource.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Shared.DataModelSource;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions options) : base(options) { }

    public DbSet<CustomerEntity> Customer => Set<CustomerEntity>();
    public DbSet<OrderEntity> Order => Set<OrderEntity>();
    public DbSet<OrderDetailEntity> OrderDetail => Set<OrderDetailEntity>();
    public DbSet<ProductEntity> Product => Set<ProductEntity>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Pobierz wszystkie typy encji zdefiniowane w kontekście bazy danych
        var entityTypes = modelBuilder.Model.GetEntityTypes();

        // Iteruj przez każdy typ encji
        foreach (var entityType in entityTypes)
        {
            // Sprawdź, czy encja dziedziczy po IBaseInformation
            if (typeof(IBaseInformation).IsAssignableFrom(entityType.ClrType))
            {
                // Ustaw indeks na polu Id dla każdej encji
                modelBuilder.Entity(entityType.ClrType)
                    .HasIndex("Id");
            }
        }

        modelBuilder.Entity<ProductEntity>()
            .Property(e => e.Price)
            .HasPrecision(18, 4);

        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified && e.Entity is IBaseInformation)
            .ToList()
            .ForEach(entry => entry.Property(nameof(IBaseInformation.UpdatedDateUtc)).CurrentValue = DateTime.UtcNow);

        return base.SaveChangesAsync(cancellationToken);
    }
}
