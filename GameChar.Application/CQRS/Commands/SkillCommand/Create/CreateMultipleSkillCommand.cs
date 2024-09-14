using GameChar.Application.DTOs;
using GameChar.Domain.ValueObjects;
using MediatR;

namespace GameChar.Application.CQRS.Commands.SkillCommand.Create;

// public record CreateMultipleCharacterCommand(string Name, int Damage, int Cooldown, Location Location) : IRequest<Guid>;
public record CreateMultipleSkillCommand(List<CreateSkillDto> CreateSkillsDto) : IRequest<List<Guid>>;