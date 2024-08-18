using Application.Features.ChassisParts.Commands.Create;
using Application.Features.ChassisParts.Commands.Delete;
using Application.Features.ChassisParts.Commands.Update;
using Application.Features.ChassisParts.Queries.GetById;
using Application.Features.ChassisParts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.ChassisParts.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChassisPartsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedChassisPartResponse>> Add([FromBody] CreateChassisPartCommand command)
    {
        CreatedChassisPartResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedChassisPartResponse>> Update([FromBody] UpdateChassisPartCommand command)
    {
        UpdatedChassisPartResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedChassisPartResponse>> Delete([FromRoute] Guid id)
    {
        DeleteChassisPartCommand command = new() { Id = id };

        DeletedChassisPartResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdChassisPartResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdChassisPartQuery query = new() { Id = id };

        GetByIdChassisPartResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListChassisPartListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListChassisPartQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListChassisPartListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicChassisPartsResponse>>> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicChassisPartsQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicChassisPartsResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}