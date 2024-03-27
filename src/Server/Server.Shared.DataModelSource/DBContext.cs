using Microsoft.EntityFrameworkCore;
using Server.Shared.DataModelSource.Entities.Abstracts;
using Server.Shared.DataModelSource.Entities.Tables;
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
        modelBuilder.Entity<CustomerEntity>().HasIndex(x => x.Id).IsUnique();

        // Pobierz wszystkie typy encji zdefiniowane w kontekście bazy danych
        var entityTypes = modelBuilder.Model.GetEntityTypes();

        // Iteruj przez każdy typ encji
        foreach (var entityType in entityTypes)
        {
            // Sprawdź, czy encja dziedziczy po BaseEntity
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
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
        // Pobierz zmodyfikowane encje z kontekstu
        var modifiedEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified)
            .Select(e => e.Entity)
            .OfType<BaseEntity>();

        // Iteruj przez każdą zmodyfikowaną encję i zaktualizuj jej pole UpdatedDateUtc
        foreach (var entity in modifiedEntities)
        {
            entity.UpdatedDateUtc = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
