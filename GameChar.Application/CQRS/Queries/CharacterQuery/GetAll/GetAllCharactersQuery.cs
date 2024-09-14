using GameChar.Application.DTOs;
using MediatR;

namespace GameChar.Application.CQRS.Queries.CharacterQuery.GetAll;

// Artık Pagination ile çalışacağız.
public record GetAllCharactersQuery(int Page = 1, int Size = 5) : IRequest<Pagination<CharacterDto>>;
