using GameChar.Application.Abstractions.Repositories.SkillRepository;
using MediatR;

namespace GameChar.Application.CQRS.Commands.SkillCommand.Update;

public class UpdateSkillCommandHandler(ISkillWriteRepository skillWriteRepository, ISkillReadRepository skillReadRepository) : IRequestHandler<UpdateSkillCommand, bool>
{
    private readonly ISkillWriteRepository _skillWriteRepository = skillWriteRepository;
    private readonly ISkillReadRepository _skillReadRepository = skillReadRepository;

    public async Task<bool> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillReadRepository.GetByIdAsync(request.Id);

        if (skill == null) return false;

        skill.Name = request.Name;
        skill.Damage = request.Damage;
        skill.Cooldown = request.Cooldown;
        skill.CharacterId = Guid.Parse(request.CharacterId);
        await _skillWriteRepository.SaveAsync();
        return true;
    }
}