using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogItemTags.Commands.Delete;

public class DeletedBlogItemTagResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TagId { get; set; }
    public Guid BlogId { get; set; }
}