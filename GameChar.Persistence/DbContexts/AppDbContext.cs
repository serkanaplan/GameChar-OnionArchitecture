using GameChar.Domain.Common;
using GameChar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameChar.Persistence.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Bu metot çağrısı, Character nesnesinin Location özelliğinin, ayrı bir tablo yerine Character tablosunun içinde bir alt nesne olarak saklanacağını belirtir. 
        // Başka bir deyişle, Location özelliği, Character nesnesine ait bir bileşen olarak kabul edilir ve veri tabanında Character tablosunun içindeki bir alanda saklanır.
        modelBuilder.Entity<Character>().OwnsOne(x => x.Location);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var data = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in data)
        {
            if (entry.State == EntityState.Added) entry.Entity.CreatedDate = DateTime.UtcNow;
            else if (entry.State == EntityState.Modified) entry.Entity.UpdatedDate = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
