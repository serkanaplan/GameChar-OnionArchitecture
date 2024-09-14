using GameChar.Application.Abstractions.Repositories.SkillRepository;
using GameChar.Persistence.Repositories.BaseRepository;
using GameChar.Persistence.DbContexts;
using GameChar.Domain.Entities;

namespace GameChar.Persistence.Repositories.SkillRepository;


public class SkillWriteRepository : WriteRepository<Skill>, ISkillWriteRepository
{
    public SkillWriteRepository(AppDbContext context) : base(context)
    {
    }
}