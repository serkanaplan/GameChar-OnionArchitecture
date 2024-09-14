using MediatR;

namespace GameChar.Application.CQRS.Queries.FileQuery;

public record GetFileQuery(string FilePath) : IRequest<byte[]>;
