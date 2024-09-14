using MediatR;

namespace GameChar.Application.CQRS.Queries.ExternalDataQuery;

public class GetExternalDataQuery : IRequest<string>
{
}
