using GameChar.Application.Abstractions.Repositories.SkillRepository;
using GameChar.Domain.Entities;
using MediatR;

namespace GameChar.Application.CQRS.Commands.SkillCommand.Create;

public class CreateMultipleSkillCommandHandler(ISkillWriteRepository skillWriteRepository) : IRequestHandler<CreateMultipleSkillCommand, List<Guid>>
{
    private readonly ISkillWriteRepository _skillRepository = skillWriteRepository;

    public async Task<List<Guid>> Handle(CreateMultipleSkillCommand request, CancellationToken cancellationToken)
    {
        // CharacterDto listesinden yeni karakterleri oluştur
        var characters = request.CreateSkillsDto.Select(characterDto => new Skill
        {
            Name = characterDto.Name,
            Damage = characterDto.Damage,
            Cooldown = characterDto.Cooldown,
            CharacterId = Guid.Parse(characterDto.CharacterId)
        }).ToList();

        await _skillRepository.AddRangeAsync(characters);
        await _skillRepository.SaveAsync();

        return characters.Select(c => c.Id).ToList();
    }
}
