using GameChar.Application.Abstractions.Repositories.SkillRepository;
using GameChar.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameChar.Application.CQRS.Queries.SkillQuery.GetAll;

public class GetAllSkillsQueryWithCharactersHandler(ISkillReadRepository skillRepository) : IRequestHandler<GetAllSkillsWithCharactersQuery, Pagination<SkillDto>>
{
    private readonly ISkillReadRepository _skillRepository = skillRepository;

    public async Task<Pagination<SkillDto>> Handle(GetAllSkillsWithCharactersQuery request, CancellationToken cancellationToken)
    {
        var totalSkillCount = await _skillRepository.GetAll().CountAsync();

        var skills = await _skillRepository.GetSkillsWithCharactersAsync(false)
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .ToListAsync();

        // Skill verilerini DTO'ya dönüştür
        var skillDtos = skills.Select(skill => new SkillDto
        {
            Id = skill.Id.ToString(),
            Name = skill.Name,
            Damage = skill.Damage,
            Cooldown = skill.Cooldown,
            CharacterId = skill.CharacterId.ToString(),
            CharacterDto = new CharacterDto {
                Id = skill.Character.Id.ToString(),
                Name = skill.Character.Name,
                Health = skill.Character.Health,
                Armor = skill.Character.Armor,
                Location = skill.Character.Location,
            }
        }).ToList();

        // Pagination nesnesini oluştur ve geri dön
        return new Pagination<SkillDto>(totalSkillCount,request.Size,request.Page,skillDtos);
    }
}
