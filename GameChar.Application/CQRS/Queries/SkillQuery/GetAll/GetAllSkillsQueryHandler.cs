using GameChar.Application.Abstractions.Repositories.SkillRepository;
using GameChar.Application.DTOs;
using MediatR;

namespace GameChar.Application.CQRS.Queries.SkillQuery.GetAll;

public class GetAllSkillsQueryHandler(ISkillReadRepository skillRepository) : IRequestHandler<GetAllSkillsQuery, Pagination<SkillDto>>
{
    private readonly ISkillReadRepository _skillRepository = skillRepository;

    public async Task<Pagination<SkillDto>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var totalSkillCount = _skillRepository.GetAll().Count();

        var skills = _skillRepository.GetAll()
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .ToList();

        // Skill verilerini DTO'ya dönüştür
        var skillDtos = skills.Select(skill => new SkillDto
        {
            Id = skill.Id.ToString(),
            Name = skill.Name,
            Damage = skill.Damage,
            Cooldown = skill.Cooldown,
            CharacterId = skill.CharacterId.ToString()
        }).ToList();

        // Pagination nesnesini oluştur ve geri dön
        return new Pagination<SkillDto>(totalSkillCount,request.Size,request.Page,skillDtos);
    }
}
