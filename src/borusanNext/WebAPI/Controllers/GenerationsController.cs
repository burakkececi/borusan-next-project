using Application.Features.Generations.Commands.Create;
using Application.Features.Generations.Commands.Delete;
using Application.Features.Generations.Commands.Update;
using Application.Features.Generations.Queries.GetById;
using Application.Features.Generations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenerationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedGenerationResponse>> Add([FromBody] CreateGenerationCommand command)
    {
        CreatedGenerationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedGenerationResponse>> Update([FromBody] UpdateGenerationCommand command)
    {
        UpdatedGenerationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedGenerationResponse>> Delete([FromRoute] Guid id)
    {
        DeleteGenerationCommand command = new() { Id = id };

        DeletedGenerationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdGenerationResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdGenerationQuery query = new() { Id = id };

        GetByIdGenerationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListGenerationQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGenerationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListGenerationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}