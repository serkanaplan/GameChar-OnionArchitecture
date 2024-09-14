using GameChar.Application.Abstractions.Repositories.BaseRepository;
using GameChar.Domain.Common;
using GameChar.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameChar.Persistence.Repositories.BaseRepository;

public class WriteRepository<T>(AppDbContext context) : IWriteRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context = context;
    public DbSet<T> Table => context.Set<T>();


    public async Task<bool> AddAsync(T entity)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }


    public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
    {
        await Table.AddRangeAsync(entities);
        return true;
    }


    public bool Remove(T entity)
    {
        EntityEntry<T> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }


    public bool RemoveRange(IEnumerable<T> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }


    public bool Update(T entity)
    {
        EntityEntry entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }


    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    public async Task<bool> RemoveAsync(string id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        return Remove(model);
    }
}