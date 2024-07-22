using Application.Features.Adverts.Commands.Create;
using Application.Features.Adverts.Commands.Delete;
using Application.Features.Adverts.Commands.Update;
using Application.Features.Adverts.Queries.GetById;
using Application.Features.Adverts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAdvertResponse>> Add([FromBody] CreateAdvertCommand command)
    {
        CreatedAdvertResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAdvertResponse>> Update([FromBody] UpdateAdvertCommand command)
    {
        UpdatedAdvertResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAdvertResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAdvertCommand command = new() { Id = id };

        DeletedAdvertResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAdvertResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAdvertQuery query = new() { Id = id };

        GetByIdAdvertResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAdvertQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAdvertListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}