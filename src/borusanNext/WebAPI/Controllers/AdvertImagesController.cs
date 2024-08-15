using Application.Features.AdvertImages.Commands.Create;
using Application.Features.AdvertImages.Commands.Delete;
using Application.Features.AdvertImages.Commands.Update;
using Application.Features.AdvertImages.Queries.GetById;
using Application.Features.AdvertImages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.AdvertImages.Queries.GetByAdvertId;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AdvertImagesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAdvertImageResponse>> Add([FromForm] CreateAdvertImageCommand command)
    {
        CreatedAdvertImageResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAdvertImageResponse>> Update([FromForm] UpdateAdvertImageCommand command)
    {
        UpdatedAdvertImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAdvertImageResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAdvertImageCommand command = new() { Id = id };

        DeletedAdvertImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAdvertImageResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAdvertImageQuery query = new() { Id = id };

        GetByIdAdvertImageResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{advertid}")]
    public async Task<ActionResult<GetByIdAdvertImageResponse>> GetByCarId([FromRoute] Guid advertid)
    {
        GetByAdvertIdAdvertImageQuery query = new() { AdvertId = advertid };

        GetListResponse<GetByAdvertIdAdvertImageResponse> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAdvertImageQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertImageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAdvertImageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}