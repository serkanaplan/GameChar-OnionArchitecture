using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameChar.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;

}