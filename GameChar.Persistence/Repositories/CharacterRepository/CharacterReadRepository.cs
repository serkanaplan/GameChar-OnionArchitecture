using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using GameChar.Domain.Entities;
using GameChar.Persistence.DbContexts;
using GameChar.Persistence.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace GameChar.Persistence.Repositories.CharacterRepository;

public class CharacterReadRepository(AppDbContext context) : ReadRepository<Character>(context), ICharacterReadRepository
{
    //     public IQueryable<Character> GetCharactersWithSkillsAsync(bool tracking = true) 
    //     => tracking ? Table.Include(x => x.Skills) : Table.Include(x => x.Skills).AsNoTracking();
    public IQueryable<Character> GetCharactersWithSkillsAsync( bool tracking)
   => GetAll(tracking).Include(x => x.Skills);

}