using Application.Features.ModalExtensions.Commands.Create;
using Application.Features.ModalExtensions.Commands.Delete;
using Application.Features.ModalExtensions.Commands.Update;
using Application.Features.ModalExtensions.Queries.GetById;
using Application.Features.ModalExtensions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.ModalExtensions.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModalExtensionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedModalExtensionResponse>> Add([FromBody] CreateModalExtensionCommand command)
    {
        CreatedModalExtensionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedModalExtensionResponse>> Update([FromBody] UpdateModalExtensionCommand command)
    {
        UpdatedModalExtensionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedModalExtensionResponse>> Delete([FromRoute] Guid id)
    {
        DeleteModalExtensionCommand command = new() { Id = id };

        DeletedModalExtensionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdModalExtensionResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdModalExtensionQuery query = new() { Id = id };

        GetByIdModalExtensionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListModalExtensionListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModalExtensionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListModalExtensionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicModalExtensionsResponse>>> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicModalExtensionsQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicModalExtensionsResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}