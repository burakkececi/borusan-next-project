using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogItemTags.Queries.GetById;

public class GetByIdBlogItemTagResponse : IResponse
{
    public Guid Id { get; set; }

    public Guid TagId { get; set; }
    public string TagName { get; set; }

    public Guid BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogDescription { get; set; }
    public string BlogBanner { get; set; }
}