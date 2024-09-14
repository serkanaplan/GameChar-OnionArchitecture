using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using GameChar.Persistence.Repositories.BaseRepository;
using GameChar.Persistence.DbContexts;
using GameChar.Domain.Entities;

namespace GameChar.Persistence.Repositories.CharacterRepository;


public class CharacterWriteRepository : WriteRepository<Character>, ICharacterWriteRepository
{
    public CharacterWriteRepository(AppDbContext context) : base(context)
    {
    }
}