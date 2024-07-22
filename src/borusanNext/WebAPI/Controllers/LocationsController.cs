using Application.Features.Locations.Commands.Create;
using Application.Features.Locations.Commands.Delete;
using Application.Features.Locations.Commands.Update;
using Application.Features.Locations.Queries.GetById;
using Application.Features.Locations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedLocationResponse>> Add([FromBody] CreateLocationCommand command)
    {
        CreatedLocationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedLocationResponse>> Update([FromBody] UpdateLocationCommand command)
    {
        UpdatedLocationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLocationResponse>> Delete([FromRoute] Guid id)
    {
        DeleteLocationCommand command = new() { Id = id };

        DeletedLocationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLocationResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdLocationQuery query = new() { Id = id };

        GetByIdLocationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLocationQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLocationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLocationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}