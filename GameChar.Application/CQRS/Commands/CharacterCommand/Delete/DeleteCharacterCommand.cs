using MediatR;

namespace GameChar.Application.CQRS.Commands.CharacterCommand.Delete;

public record DeleteCharacterCommand(string Id) : IRequest<bool>;
