
using GameChar.Application.CQRS.Commands.CharacterCommand.Create;
using GameChar.Application.CQRS.Commands.CharacterCommand.Delete;
using GameChar.Application.CQRS.Commands.CharacterCommand.Update;
using GameChar.Application.CQRS.Queries.CharacterQuery.GetAll;
using GameChar.Application.CQRS.Queries.CharacterQuery.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameChar.API.Controllers;

public class CharacterController(IMediator mediator) : BaseController(mediator)
{

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCharactersQuery getAllCharactersQuery)
    {
        var characters = await _mediator.Send(getAllCharactersQuery);
        return Ok(characters);
    }

    [HttpGet("with-skills")]
    public async Task<IActionResult> GetAllCharactersWithSkills([FromQuery] GetAllCharactersWithSkillsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetCharacterByIdQuery getCharacterByIdQuery)
    {
        var character = await _mediator.Send(getCharacterByIdQuery);
        if (character == null) return NotFound();
        return Ok(character);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCharacterCommand command)
    {
        var result = await _mediator.Send(command);
        if (result == null) return BadRequest("Character creation failed");
        return Ok(result);
    }

    [HttpPost("add-multiple")]
    public async Task<IActionResult> CreateMultiple([FromBody] CreateMultipleCharactersCommand command)
    {
        var characterIds = await _mediator.Send(command);
        return Ok(characterIds);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCharacterCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result) return BadRequest("Update failed");
        return NoContent();
    }


    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteCharacterCommand deleteCharacterCommand)
    {
        var result = await _mediator.Send(deleteCharacterCommand);
        if (!result) return BadRequest("Delete failed");
        return NoContent();
    }
}
