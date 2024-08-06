using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogItemTags.Commands.Delete;

public class DeletedBlogItemTagResponse : IResponse
{
    public Guid Id { get; set; }
}