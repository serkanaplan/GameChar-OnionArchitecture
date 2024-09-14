using GameChar.Application.DTOs;
using MediatR;

namespace GameChar.Application.CQRS.Queries.SkillQuery.GetAll;

public record GetAllSkillsWithCharactersQuery(int Page = 1, int Size = 5) : IRequest<Pagination<SkillDto>>;
