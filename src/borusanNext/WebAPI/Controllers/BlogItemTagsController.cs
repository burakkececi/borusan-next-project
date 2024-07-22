using Application.Features.BlogItemTags.Commands.Create;
using Application.Features.BlogItemTags.Commands.Delete;
using Application.Features.BlogItemTags.Commands.Update;
using Application.Features.BlogItemTags.Queries.GetById;
using Application.Features.BlogItemTags.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogItemTagsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBlogItemTagResponse>> Add([FromBody] CreateBlogItemTagCommand command)
    {
        CreatedBlogItemTagResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBlogItemTagResponse>> Update([FromBody] UpdateBlogItemTagCommand command)
    {
        UpdatedBlogItemTagResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBlogItemTagResponse>> Delete([FromRoute] Guid id)
    {
        DeleteBlogItemTagCommand command = new() { Id = id };

        DeletedBlogItemTagResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBlogItemTagResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdBlogItemTagQuery query = new() { Id = id };

        GetByIdBlogItemTagResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBlogItemTagQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBlogItemTagQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBlogItemTagListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}