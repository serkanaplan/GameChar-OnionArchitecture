using MediatR;

namespace GameChar.Application.CQRS.Commands.SkillCommand.Delete;

public record DeleteSkillCommand(string Id) : IRequest<bool>;