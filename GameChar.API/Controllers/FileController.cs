using GameChar.Application.CQRS.Queries.FileQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameChar.API.Controllers;

public class FileController(IMediator mediator) : BaseController(mediator)
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("read-file")]
    public async Task<IActionResult> GetFile([FromQuery] string filePath)
    {
        var query = new GetFileQuery(filePath);
        var fileContent = await _mediator.Send(query);

        if (fileContent == null || fileContent.Length == 0)
            return NotFound();

        return File(fileContent, "application/octet-stream", "downloadedFile");
    }
}
