using GameChar.Application.CQRS.Commands.SkillCommand.Create;
using GameChar.Application.CQRS.Commands.SkillCommand.Delete;
using GameChar.Application.CQRS.Commands.SkillCommand.Update;
using GameChar.Application.CQRS.Queries.SkillQuery.GetAll;
using GameChar.Application.CQRS.Queries.SkillQuery.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameChar.API.Controllers;

public class SkillController(IMediator mediator) : BaseController(mediator)
{

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllSkillsQuery getAllSkillsQuery)
    {
        var skills = await _mediator.Send(getAllSkillsQuery);
        return Ok(skills);
    }

    [HttpGet("with-characters")]
    public async Task<IActionResult> GetAllSkilsWithCharacters([FromQuery] GetAllSkillsWithCharactersQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetSkillByIdQuery getSkillByIdQuery)
    {
        var skill = await _mediator.Send(getSkillByIdQuery);
        if (skill == null) return NotFound();
        return Ok(skill);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSkillCommand createSkillCommand)
    {
        var result = await _mediator.Send(createSkillCommand);
        if (result == null) return BadRequest("Character creation failed");
        return Ok(result);
    }

    [HttpPost("add-multiple")]
    public async Task<IActionResult> CreateMultiple([FromBody] CreateMultipleSkillCommand command)
    {
        var characterIds = await _mediator.Send(command);
        return Ok(characterIds);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSkillCommand updateSkillCommand)
    {
        var result = await _mediator.Send(updateSkillCommand);
        if (!result) return BadRequest("Update failed");
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteSkillCommand deleteSkillCommand)
    {
        var result = await _mediator.Send(deleteSkillCommand);
        if (!result) return BadRequest("Delete failed");
        return NoContent();
    }

}