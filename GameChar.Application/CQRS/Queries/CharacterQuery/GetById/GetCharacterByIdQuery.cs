using GameChar.Application.DTOs;
using MediatR;

namespace GameChar.Application.CQRS.Queries.CharacterQuery.GetById;

public record GetCharacterByIdQuery(string Id) : IRequest<CharacterDto>;
