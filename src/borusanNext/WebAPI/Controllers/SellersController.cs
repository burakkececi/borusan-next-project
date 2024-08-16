using Application.Features.Sellers.Commands.Create;
using Application.Features.Sellers.Commands.Delete;
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Queries.GetById;
using Application.Features.Sellers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.Sellers.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSellerResponse>> Add([FromBody] CreateSellerCommand command)
    {
        CreatedSellerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSellerResponse>> Update([FromBody] UpdateSellerCommand command)
    {
        UpdatedSellerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSellerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSellerCommand command = new() { Id = id };

        DeletedSellerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSellerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSellerQuery query = new() { Id = id };

        GetByIdSellerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSellerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSellerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSellerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<IActionResult> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicSellerQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicSellerResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}