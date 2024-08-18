using Application.Features.Tags.Commands.Create;
using Application.Features.Tags.Commands.Delete;
using Application.Features.Tags.Commands.Update;
using Application.Features.Tags.Queries.GetById;
using Application.Features.Tags.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTagResponse>> Add([FromBody] CreateTagCommand command)
    {
        CreatedTagResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTagResponse>> Update([FromBody] UpdateTagCommand command)
    {
        UpdatedTagResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTagResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTagCommand command = new() { Id = id };

        DeletedTagResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTagResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTagQuery query = new() { Id = id };

        GetByIdTagResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListTagListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTagQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTagListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}