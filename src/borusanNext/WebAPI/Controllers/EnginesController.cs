using Application.Features.Engines.Commands.Create;
using Application.Features.Engines.Commands.Delete;
using Application.Features.Engines.Commands.Update;
using Application.Features.Engines.Queries.GetById;
using Application.Features.Engines.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.Engines.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnginesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedEngineResponse>> Add([FromBody] CreateEngineCommand command)
    {
        CreatedEngineResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedEngineResponse>> Update([FromBody] UpdateEngineCommand command)
    {
        UpdatedEngineResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedEngineResponse>> Delete([FromRoute] Guid id)
    {
        DeleteEngineCommand command = new() { Id = id };

        DeletedEngineResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdEngineResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdEngineQuery query = new() { Id = id };

        GetByIdEngineResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListEngineListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEngineQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListEngineListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicEngineResponse>>> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicEngineQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicEngineResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}