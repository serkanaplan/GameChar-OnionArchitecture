
using GameChar.Domain.ValueObjects;
using MediatR;

namespace GameChar.Application.CQRS.Commands.CharacterCommand.Update;

public record UpdateCharacterCommand(
    string Id,
    string Name,
    int Health,
    int Armor,
    Location Location) : IRequest<bool>;
