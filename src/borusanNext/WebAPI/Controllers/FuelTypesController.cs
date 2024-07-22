using Application.Features.FuelTypes.Commands.Create;
using Application.Features.FuelTypes.Commands.Delete;
using Application.Features.FuelTypes.Commands.Update;
using Application.Features.FuelTypes.Queries.GetById;
using Application.Features.FuelTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedFuelTypeResponse>> Add([FromBody] CreateFuelTypeCommand command)
    {
        CreatedFuelTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedFuelTypeResponse>> Update([FromBody] UpdateFuelTypeCommand command)
    {
        UpdatedFuelTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedFuelTypeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteFuelTypeCommand command = new() { Id = id };

        DeletedFuelTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdFuelTypeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdFuelTypeQuery query = new() { Id = id };

        GetByIdFuelTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListFuelTypeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFuelTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListFuelTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}