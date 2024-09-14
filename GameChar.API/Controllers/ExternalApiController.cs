using GameChar.Application.CQRS.Queries.ExternalDataQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameChar.API.Controllers;

public class ExternalApiController(IMediator mediator) : BaseController(mediator)
{
    private readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> GetExternalData()
    {
        var query = new GetExternalDataQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
