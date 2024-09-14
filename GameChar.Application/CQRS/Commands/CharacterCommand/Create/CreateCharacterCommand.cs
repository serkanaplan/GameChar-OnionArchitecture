using GameChar.Application.DTOs;
using GameChar.Domain.ValueObjects;
using MediatR;


namespace GameChar.Application.CQRS.Commands.CharacterCommand.Create;


// public record CreateCharacterCommand(CreateCharacterDto CreateCharacterDto) : IRequest<Guid>;
public record CreateCharacterCommand(string Name,int Health,int Armor,Location Location) : IRequest<Guid>;
