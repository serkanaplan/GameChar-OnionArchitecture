using GameChar.Persistence.DbContexts;
using GameChar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GameChar.Persistence.Repositories.BaseRepository;
using GameChar.Application.Abstractions.Repositories.SkillRepository;

namespace GameChar.Persistence.Repositories.SkillRepository;

public class SkillReadRepository(AppDbContext dbContext) : ReadRepository<Skill>(dbContext), ISkillReadRepository
{
    // public IQueryable<Skill> GetSkillsWithCharactersAsync(bool tracking = true) 
    // => tracking ? Table.Include(x => x.Character) : Table.Include(x => x.Character).AsNoTracking();

    public IQueryable<Skill> GetSkillsWithCharactersAsync(bool tracking = true)
    => GetAll().Include(x => x.Character);
}