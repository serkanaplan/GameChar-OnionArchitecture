using GameChar.Application.Abstractions.Repositories.SkillRepository;
using GameChar.Application.DTOs;
using MediatR;

namespace GameChar.Application.CQRS.Queries.SkillQuery.GetById;

public class GetSkillByIdQueryHandler(ISkillReadRepository skillReadRepository) : IRequestHandler<GetSkillByIdQuery, SkillDto>
{
    private readonly ISkillReadRepository _skillReadRepository = skillReadRepository;

    public async Task<SkillDto> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var character = await _skillReadRepository.GetByIdAsync(request.Id, false);

        if (character == null) return null; // Karakter bulunamadı

        // Dönüş tipini DTO ile dönüyoruz
        return new SkillDto
        {
            Id = character.Id.ToString(),
            Name = character.Name,
            Damage = character.Damage,
            Cooldown = character.Cooldown,
            CharacterId = character.CharacterId.ToString(),
        };
    }
}

