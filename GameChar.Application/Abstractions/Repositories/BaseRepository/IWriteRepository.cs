using GameChar.Domain.Common;

namespace GameChar.Application.Abstractions.Repositories.BaseRepository;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(IEnumerable<T> entities);
    bool Update(T entity);
    bool Remove(T entity);
    bool RemoveRange(IEnumerable<T> entities);
    Task<bool> RemoveAsync(string id);
    Task<int> SaveAsync();
}