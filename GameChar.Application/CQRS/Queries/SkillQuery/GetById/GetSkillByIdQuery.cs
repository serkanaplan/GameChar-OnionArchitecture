using GameChar.Application.DTOs;
using MediatR;

namespace GameChar.Application.CQRS.Queries.SkillQuery.GetById;

public record GetSkillByIdQuery(string Id) : IRequest<SkillDto>;

