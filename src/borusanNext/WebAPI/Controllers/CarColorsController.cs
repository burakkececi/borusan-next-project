using Application.Features.CarColors.Commands.Create;
using Application.Features.CarColors.Commands.Delete;
using Application.Features.CarColors.Commands.Update;
using Application.Features.CarColors.Queries.GetById;
using Application.Features.CarColors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.CarColors.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarColorsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCarColorResponse>> Add([FromBody] CreateCarColorCommand command)
    {
        CreatedCarColorResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCarColorResponse>> Update([FromBody] UpdateCarColorCommand command)
    {
        UpdatedCarColorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCarColorResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCarColorCommand command = new() { Id = id };

        DeletedCarColorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCarColorResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCarColorQuery query = new() { Id = id };

        GetByIdCarColorResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCarColorListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCarColorQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCarColorListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicColorResponse>>> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicColorQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicColorResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}