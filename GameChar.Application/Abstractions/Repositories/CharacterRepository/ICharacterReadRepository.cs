using GameChar.Application.Abstractions.Repositories.BaseRepository;
using GameChar.Domain.Entities;

namespace GameChar.Application.Abstractions.Repositories.CharacterRepository;

public interface ICharacterReadRepository : IReadRepository<Character>
{
    IQueryable<Character> GetCharactersWithSkillsAsync(bool tracking);
}
