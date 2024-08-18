using Application.Features.BodyShellParts.Commands.Create;
using Application.Features.BodyShellParts.Commands.Delete;
using Application.Features.BodyShellParts.Commands.Update;
using Application.Features.BodyShellParts.Queries.GetById;
using Application.Features.BodyShellParts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.BodyShellParts.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BodyShellPartsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBodyShellPartResponse>> Add([FromBody] CreateBodyShellPartCommand command)
    {
        CreatedBodyShellPartResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBodyShellPartResponse>> Update([FromBody] UpdateBodyShellPartCommand command)
    {
        UpdatedBodyShellPartResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBodyShellPartResponse>> Delete([FromRoute] Guid id)
    {
        DeleteBodyShellPartCommand command = new() { Id = id };

        DeletedBodyShellPartResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBodyShellPartResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdBodyShellPartQuery query = new() { Id = id };

        GetByIdBodyShellPartResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListBodyShellPartListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBodyShellPartQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBodyShellPartListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicBodyShellPartsResponse>>> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicBodyShellPartsQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicBodyShellPartsResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}