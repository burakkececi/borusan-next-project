using Application.Features.CustomerAdvertLogs.Commands.Create;
using Application.Features.CustomerAdvertLogs.Commands.Delete;
using Application.Features.CustomerAdvertLogs.Commands.Update;
using Application.Features.CustomerAdvertLogs.Queries.GetById;
using Application.Features.CustomerAdvertLogs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerAdvertLogsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCustomerAdvertLogResponse>> Add([FromBody] CreateCustomerAdvertLogCommand command)
    {
        CreatedCustomerAdvertLogResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCustomerAdvertLogResponse>> Update([FromBody] UpdateCustomerAdvertLogCommand command)
    {
        UpdatedCustomerAdvertLogResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCustomerAdvertLogResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCustomerAdvertLogCommand command = new() { Id = id };

        DeletedCustomerAdvertLogResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCustomerAdvertLogResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCustomerAdvertLogQuery query = new() { Id = id };

        GetByIdCustomerAdvertLogResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCustomerAdvertLogQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerAdvertLogQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCustomerAdvertLogListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}