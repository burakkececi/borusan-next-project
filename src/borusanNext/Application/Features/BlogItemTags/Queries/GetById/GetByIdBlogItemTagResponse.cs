using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogItemTags.Queries.GetById;

public class GetByIdBlogItemTagResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TagId { get; set; }
    public Guid BlogId { get; set; }
}