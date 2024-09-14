using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using GameChar.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameChar.Application.CQRS.Queries.CharacterQuery.GetAll;

public class GetAllCharactersWithSkillsQueryHandler(ICharacterReadRepository characterRepository) : IRequestHandler<GetAllCharactersWithSkillsQuery, Pagination<CharacterDto>>
{
    private readonly ICharacterReadRepository _characterRepository = characterRepository;

    public async Task<Pagination<CharacterDto>> Handle(GetAllCharactersWithSkillsQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _characterRepository.GetAll().CountAsync();

        var characters = await _characterRepository.GetCharactersWithSkillsAsync(false)
            .Skip((request.Page - 1) * request.Size)  // Sayfayı atlıyoruz
            .Take(request.Size)
            .ToListAsync(cancellationToken);

        // DTO'ya map ediyoruz
        var characterDtos = characters.Select(character => new CharacterDto
        {
            Id = character.Id.ToString(),
            Name = character.Name,
            Health = character.Health,
            Armor = character.Armor,
            Location = character.Location,
            Skills = character.Skills.Select(s => new SkillDto
            {
                Id = s.Id.ToString(),
                Name = s.Name,
                Damage = s.Damage,
                Cooldown = s.Cooldown
            }).ToList()
        }).ToList();

        // Pagination sınıfı ile veriyi geri dönüyoruz
        return new Pagination<CharacterDto>(totalCount, request.Size, request.Page, characterDtos);
    }
}
