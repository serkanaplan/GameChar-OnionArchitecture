using MediatR;

namespace GameChar.Application.CQRS.Commands.SkillCommand.Create;

public record CreateSkillCommand(string Name, int Damage, int Cooldown, string CharacterId) : IRequest<Guid>;