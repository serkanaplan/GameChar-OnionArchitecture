using GameChar.Application.Abstractions.Repositories.SkillRepository;
using GameChar.Domain.Entities;
using MediatR;

namespace GameChar.Application.CQRS.Commands.SkillCommand.Create;


public class CreateSkillCommandHandler(ISkillWriteRepository skillWriteRepository) : IRequestHandler<CreateSkillCommand, Guid>
{
    private readonly ISkillWriteRepository _skillWriteRepository = skillWriteRepository;    
    public async Task<Guid> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill
        {
            Name = request.Name,
            Damage = request.Damage,
            Cooldown = request.Cooldown,
            CharacterId = Guid.Parse(request.CharacterId)
        };
        await skillWriteRepository.AddAsync(skill);
        await skillWriteRepository.SaveAsync();
        return skill.Id;
    }
}