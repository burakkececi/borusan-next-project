using Application.Features.FuelConsumptions.Commands.Create;
using Application.Features.FuelConsumptions.Commands.Delete;
using Application.Features.FuelConsumptions.Commands.Update;
using Application.Features.FuelConsumptions.Queries.GetById;
using Application.Features.FuelConsumptions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelConsumptionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedFuelConsumptionResponse>> Add([FromBody] CreateFuelConsumptionCommand command)
    {
        CreatedFuelConsumptionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedFuelConsumptionResponse>> Update([FromBody] UpdateFuelConsumptionCommand command)
    {
        UpdatedFuelConsumptionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedFuelConsumptionResponse>> Delete([FromRoute] Guid id)
    {
        DeleteFuelConsumptionCommand command = new() { Id = id };

        DeletedFuelConsumptionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdFuelConsumptionResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdFuelConsumptionQuery query = new() { Id = id };

        GetByIdFuelConsumptionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListFuelConsumptionQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFuelConsumptionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListFuelConsumptionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}