using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Queries.GetById;
using Application.Features.Customers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.Customers.Queries.GetDynamic;
using Application.Features.Customers.Queries.GetByUserId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCustomerResponse>> Add([FromBody] CreateCustomerCommand command)
    {
        CreatedCustomerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCustomerResponse>> Update([FromBody] UpdateCustomerCommand command)
    {
        UpdatedCustomerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCustomerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCustomerCommand command = new() { Id = id };

        DeletedCustomerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCustomerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCustomerQuery query = new() { Id = id };

        GetByIdCustomerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("user/{id}")]
    public async Task<ActionResult<GetByUserIdCustomerResponse>> GetByUserId([FromRoute] Guid id)
    {
        GetByUserIdCustomerQuery query = new() { UserId = id };

        GetByUserIdCustomerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCustomerListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCustomerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicCustomerResponse>>> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicCustomerQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicCustomerResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}