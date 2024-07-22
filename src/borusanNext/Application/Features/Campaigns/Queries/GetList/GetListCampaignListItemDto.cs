using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Campaigns.Queries.GetList;

public class GetListCampaignListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Banner { get; set; }
}