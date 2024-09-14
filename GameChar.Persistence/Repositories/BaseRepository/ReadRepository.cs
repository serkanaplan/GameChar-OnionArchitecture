using System.Linq.Expressions;
using GameChar.Application.Abstractions.Repositories.BaseRepository;
using GameChar.Domain.Common;
using GameChar.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GameChar.Persistence.Repositories.BaseRepository;

public class ReadRepository<T>(AppDbContext context) : IReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context = context;
    public DbSet<T> Table => _context.Set<T>();

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true)
    => tracking ? Table.AnyAsync(expression) : Table.AsNoTracking().AnyAsync(expression);

    public IQueryable<T> GetAll(bool tracking = true) => tracking ? Table : Table.AsNoTracking();

    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    => await (tracking ? Table : Table.AsNoTracking()).FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

    public IQueryable<T> Where(Expression<Func<T, bool>> expression, bool tracking = true)
    => tracking ? Table.Where(expression) : Table.Where(expression).AsNoTracking();
}