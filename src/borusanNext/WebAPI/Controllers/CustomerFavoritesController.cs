using Application.Features.CustomerFavorites.Commands.Create;
using Application.Features.CustomerFavorites.Commands.Delete;
using Application.Features.CustomerFavorites.Commands.Update;
using Application.Features.CustomerFavorites.Queries.GetById;
using Application.Features.CustomerFavorites.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerFavoritesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCustomerFavoriteResponse>> Add([FromBody] CreateCustomerFavoriteCommand command)
    {
        CreatedCustomerFavoriteResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCustomerFavoriteResponse>> Update([FromBody] UpdateCustomerFavoriteCommand command)
    {
        UpdatedCustomerFavoriteResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCustomerFavoriteResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCustomerFavoriteCommand command = new() { Id = id };

        DeletedCustomerFavoriteResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCustomerFavoriteResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCustomerFavoriteQuery query = new() { Id = id };

        GetByIdCustomerFavoriteResponse response = await Mediator.Send(query);

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