using Application.Features.Campaigns.Constants;
using Application.Features.Campaigns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Campaigns.Constants.CampaignsOperationClaims;

namespace Application.Features.Campaigns.Commands.Create;

public class CreateCampaignCommand : IRequest<CreatedCampaignResponse>, ISecuredRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Banner { get; set; }

    public string[] Roles => [Admin, Write, CampaignsOperationClaims.Create];

    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, CreatedCampaignResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly CampaignBusinessRules _campaignBusinessRules;

        public CreateCampaignCommandHandler(IMapper mapper, ICampaignRepository campaignRepository,
                                         CampaignBusinessRules campaignBusinessRules)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _campaignBusinessRules = campaignBusinessRules;
        }

        public async Task<CreatedCampaignResponse> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            Campaign campaign = _mapper.Map<Campaign>(request);

            await _campaignRepository.AddAsync(campaign);

            CreatedCampaignResponse response = _mapper.Map<CreatedCampaignResponse>(campaign);
            return response;
        }
    }
}