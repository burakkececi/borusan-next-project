using Application.Features.BodyTypes.Commands.Create;
using Application.Features.BodyTypes.Commands.Delete;
using Application.Features.BodyTypes.Commands.Update;
using Application.Features.BodyTypes.Queries.GetById;
using Application.Features.BodyTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.BodyTypes.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BodyTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBodyTypeResponse>> Add([FromBody] CreateBodyTypeCommand command)
    {
        CreatedBodyTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBodyTypeResponse>> Update([FromBody] UpdateBodyTypeCommand command)
    {
        UpdatedBodyTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBodyTypeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteBodyTypeCommand command = new() { Id = id };

        DeletedBodyTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBodyTypeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdBodyTypeQuery query = new() { Id = id };

        GetByIdBodyTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBodyTypeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBodyTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBodyTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<IActionResult> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicBodyTypesQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicBodyTypesResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}