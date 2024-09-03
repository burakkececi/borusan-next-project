using Application.Features.CustomerFavorites.Commands.Create;
using Application.Features.CustomerFavorites.Commands.Delete;
using Application.Features.CustomerFavorites.Commands.Update;
using Application.Features.CustomerFavorites.Queries.GetById;
using Application.Features.CustomerFavorites.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.CustomerFavorites.Queries.GetByCustomerId;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerFavoritesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Add([FromBody] CreateCustomerFavoriteCommand command)
    {
        var response = await Mediator.Send(command);
        return Created(nameof(Add), response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerFavoriteCommand command)
    {
        await Mediator.Send(command);

        return Ok("Update in process...");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCustomerFavoriteCommand command = new() { Id = id };

        await Mediator.Send(command);

        return Ok("Delete in process...");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCustomerFavoriteResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCustomerFavoriteQuery query = new() { Id = id };

        GetByIdCustomerFavoriteResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<GetListResponse<GetByCustomerIdCustomerFavoriteListItemDto>>> GetByCustomerId([FromQuery] PageRequest pageRequest, [FromRoute] Guid customerId)
    {
        GetByCustomerIdCustomerFavoriteQuery query = new() { PageRequest = pageRequest, CustomerId = customerId };

        GetListResponse<GetByCustomerIdCustomerFavoriteListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCustomerFavoriteListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerFavoriteQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCustomerFavoriteListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}