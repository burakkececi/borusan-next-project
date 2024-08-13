using Application.Features.Licences.Commands.Create;
using Application.Features.Licences.Commands.Delete;
using Application.Features.Licences.Commands.Update;
using Application.Features.Licences.Queries.GetById;
using Application.Features.Licences.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Models.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.Licences.Queries.GetDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LicencesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedLicenceResponse>> Add([FromBody] CreateLicenceCommand command)
    {
        CreatedLicenceResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedLicenceResponse>> Update([FromBody] UpdateLicenceCommand command)
    {
        UpdatedLicenceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLicenceResponse>> Delete([FromRoute] Guid id)
    {
        DeleteLicenceCommand command = new() { Id = id };

        DeletedLicenceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLicenceResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdLicenceQuery query = new() { Id = id };

        GetByIdLicenceResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLicenceQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLicenceQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLicenceListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<IActionResult> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicLicenseQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };

        GetListResponse<GetDynamicLicenceResponse> response = await Mediator.Send(getDynamicQuery);

        return Ok(response);
    }
}