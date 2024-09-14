using GameChar.Application.DTOs;
using MediatR;

namespace GameChar.Application.CQRS.Commands.CharacterCommand.Create;

// public record CreateMultipleCharactersCommand(string Name,int Health,int Armor,Location Location) : IRequest<Guid>;

public record CreateMultipleCharactersCommand(List<CreateCharacterDto> CreateCharactersDto) : IRequest<List<Guid>>;