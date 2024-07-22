using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BlogItemTags.Queries.GetList;

public class GetListBlogItemTagListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TagId { get; set; }
    public Guid BlogId { get; set; }
}