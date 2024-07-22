using Application.Features.Campaigns.Constants;
using Application.Features.Campaigns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Campaigns.Constants.CampaignsOperationClaims;

namespace Application.Features.Campaigns.Commands.Update;

public class UpdateCampaignCommand : IRequest<UpdatedCampaignResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Banner { get; set; }

    public string[] Roles => [Admin, Write, CampaignsOperationClaims.Update];

    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, UpdatedCampaignResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly CampaignBusinessRules _campaignBusinessRules;

        public UpdateCampaignCommandHandler(IMapper mapper, ICampaignRepository campaignRepository,
                                         CampaignBusinessRules campaignBusinessRules)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _campaignBusinessRules = campaignBusinessRules;
        }

        public async Task<UpdatedCampaignResponse> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            Campaign? campaign = await _campaignRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _campaignBusinessRules.CampaignShouldExistWhenSelected(campaign);
            campaign = _mapper.Map(request, campaign);

            await _campaignRepository.UpdateAsync(campaign!);

            UpdatedCampaignResponse response = _mapper.Map<UpdatedCampaignResponse>(campaign);
            return response;
        }
    }
}