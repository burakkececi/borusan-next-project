using Application.Features.ExpertizeResults.Commands.Create;
using Application.Features.ExpertizeResults.Commands.Delete;
using Application.Features.ExpertizeResults.Commands.Update;
using Application.Features.ExpertizeResults.Queries.GetById;
using Application.Features.ExpertizeResults.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.ExpertizeResults.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpertizeResultsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedExpertizeResultResponse>> Add([FromBody] CreateExpertizeResultCommand command)
    {
        CreatedExpertizeResultResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedExpertizeResultResponse>> Update([FromBody] UpdateExpertizeResultCommand command)
    {
        UpdatedExpertizeResultResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedExpertizeResultResponse>> Delete([FromRoute] Guid id)
    {
        DeleteExpertizeResultCommand command = new() { Id = id };

        DeletedExpertizeResultResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdExpertizeResultResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdExpertizeResultQuery query = new() { Id = id };

        GetByIdExpertizeResultResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListExpertizeResultListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListExpertizeResultQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListExpertizeResultListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicExpertizeResponse>>> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicExpertizeResultQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicExpertizeResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}