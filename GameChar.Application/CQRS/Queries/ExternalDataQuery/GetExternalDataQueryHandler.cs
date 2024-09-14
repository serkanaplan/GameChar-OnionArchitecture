using GameChar.Application.Abstractions.Services;
using MediatR;

namespace GameChar.Application.CQRS.Queries.ExternalDataQuery;

public class GetExternalDataQueryHandler(IExternalApiService externalApiService) : IRequestHandler<GetExternalDataQuery, string>
{
    private readonly IExternalApiService _externalApiService = externalApiService;

    public async Task<string> Handle(GetExternalDataQuery request, CancellationToken cancellationToken)
    {
        return await _externalApiService.GetExternalDataAsync();
    }
}
