using System.Linq.Expressions;
using GameChar.Domain.Common;

namespace GameChar.Application.Abstractions.Repositories.BaseRepository;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(string id, bool tracking = true);
    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> Where(Expression<Func<T, bool>> expression, bool tracking = true);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true);
}