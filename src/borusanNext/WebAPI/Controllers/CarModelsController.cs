using Application.Features.CarModels.Commands.Create;
using Application.Features.CarModels.Commands.Delete;
using Application.Features.CarModels.Commands.Update;
using Application.Features.CarModels.Queries.GetById;
using Application.Features.CarModels.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarModelsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCarModelResponse>> Add([FromBody] CreateCarModelCommand command)
    {
        CreatedCarModelResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCarModelResponse>> Update([FromBody] UpdateCarModelCommand command)
    {
        UpdatedCarModelResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCarModelResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCarModelCommand command = new() { Id = id };

        DeletedCarModelResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCarModelResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCarModelQuery query = new() { Id = id };

        GetByIdCarModelResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCarModelQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCarModelQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCarModelListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}