using MediatR;

namespace GameChar.Application.CQRS.Commands.SkillCommand.Update;

public record UpdateSkillCommand : IRequest<bool>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Cooldown { get; set; }
    public string CharacterId { get; set; }
}