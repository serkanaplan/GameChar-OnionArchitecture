using GameChar.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace GameChar.Application.Abstractions.Repositories.BaseRepository;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}