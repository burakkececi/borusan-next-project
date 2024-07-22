using NArchitecture.Core.Application.Responses;

namespace Application.Features.Campaigns.Commands.Update;

public class UpdatedCampaignResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Banner { get; set; }
}