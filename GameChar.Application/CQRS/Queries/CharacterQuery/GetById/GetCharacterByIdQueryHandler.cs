using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using GameChar.Application.DTOs;
using MediatR;

namespace GameChar.Application.CQRS.Queries.CharacterQuery.GetById;

public class GetCharacterByIdQueryHandler(ICharacterReadRepository characterRepository) : IRequestHandler<GetCharacterByIdQuery, CharacterDto>
{
    private readonly ICharacterReadRepository _characterRepository = characterRepository;

    public async Task<CharacterDto> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
    {
        var character = await _characterRepository.GetByIdAsync(request.Id, false);

        if (character == null) return null; // Karakter bulunamadı

        // Dönüş tipini DTO ile dönüyoruz
        return new CharacterDto
        {
            Id = character.Id.ToString(),
            Name = character.Name,
            Health = character.Health,
            Armor = character.Armor,
            Location = character.Location,
            Skills = character.Skills.Select(s => new SkillDto {Id = s.Id.ToString(), Name = s.Name ,Damage = s.Damage,Cooldown = s.Cooldown}).ToList(),
        };
    }
}

