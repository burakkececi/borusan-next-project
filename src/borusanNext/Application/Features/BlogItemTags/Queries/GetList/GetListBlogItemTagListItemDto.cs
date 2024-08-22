using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BlogItemTags.Queries.GetList;

public class GetListBlogItemTagListItemDto : IDto
{
    public Guid Id { get; set; }

    public Guid TagId { get; set; }
    public string TagName { get; set; }

    public Guid BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogDescription { get; set; }
    public DateTime CreatedDate { get; set; }
}