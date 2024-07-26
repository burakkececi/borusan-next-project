using Application.Features.Campaigns.Constants;
using Application.Features.Campaigns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Campaigns.Constants.CampaignsOperationClaims;
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.Campaigns.Commands.Update;

public class UpdateCampaignCommand : IRequest<UpdatedCampaignResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Banner { get; set; }

    public string[] Roles => [Admin, Write, CampaignsOperationClaims.Update];

    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, UpdatedCampaignResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly CampaignBusinessRules _campaignBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public UpdateCampaignCommandHandler(IMapper mapper, ICampaignRepository campaignRepository,
                                         CampaignBusinessRules campaignBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _campaignBusinessRules = campaignBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<UpdatedCampaignResponse> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            Campaign? campaign = await _campaignRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _campaignBusinessRules.CampaignShouldExistWhenSelected(campaign);
            campaign = _mapper.Map(request, campaign);

            campaign.Banner = await _imageServiceBase.UpdateAsync(request.Banner, campaign.Banner);

            await _campaignRepository.UpdateAsync(campaign!);

            UpdatedCampaignResponse response = _mapper.Map<UpdatedCampaignResponse>(campaign);
            return response;
        }
    }
}