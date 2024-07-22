using NArchitecture.Core.Application.Responses;

namespace Application.Features.Campaigns.Queries.GetById;

public class GetByIdCampaignResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Banner { get; set; }
}