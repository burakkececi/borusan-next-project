using Application.Features.GenerationImages.Commands.Create;
using Application.Features.GenerationImages.Commands.Delete;
using Application.Features.GenerationImages.Commands.Update;
using Application.Features.GenerationImages.Queries.GetById;
using Application.Features.GenerationImages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenerationImagesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedGenerationImageResponse>> Add([FromForm] CreateGenerationImageCommand command)
    {
        CreatedGenerationImageResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedGenerationImageResponse>> Update([FromForm] UpdateGenerationImageCommand command)
    {
        UpdatedGenerationImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedGenerationImageResponse>> Delete([FromRoute] Guid id)
    {
        DeleteGenerationImageCommand command = new() { Id = id };

        DeletedGenerationImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdGenerationImageResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdGenerationImageQuery query = new() { Id = id };

        GetByIdGenerationImageResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListGenerationImageQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGenerationImageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListGenerationImageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}