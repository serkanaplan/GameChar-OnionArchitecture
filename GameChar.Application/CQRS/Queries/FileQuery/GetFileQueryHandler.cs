using GameChar.Application.Abstractions.Services;
using MediatR;

namespace GameChar.Application.CQRS.Queries.FileQuery;

public class GetFileQueryHandler(IFileService fileService) : IRequestHandler<GetFileQuery, byte[]>
{
    private readonly IFileService _fileService = fileService;

    public async Task<byte[]> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        return await _fileService.ReadFileAsync(request.FilePath);
    }
}
