using GameChar.Application.Abstractions.Repositories.BaseRepository;
using GameChar.Domain.Entities;

namespace GameChar.Application.Abstractions.Repositories.SkillRepository;

public interface ISkillReadRepository : IReadRepository<Skill>
{
   IQueryable<Skill> GetSkillsWithCharactersAsync(bool tracking = true);
}