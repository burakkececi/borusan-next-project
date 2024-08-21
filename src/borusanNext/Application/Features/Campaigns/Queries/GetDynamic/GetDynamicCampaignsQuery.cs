using Application.Features.Campaigns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Campaigns.Constants.CampaignsOperationClaims;


namespace Application.Features.Campaigns.Queries.GetDynamic;
public class GetDynamicCampaignsQuery:IRequest<GetListResponse<GetDynamicCampaignsResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicCampaignsQueryHandler : IRequestHandler<GetDynamicCampaignsQuery, GetListResponse<GetDynamicCampaignsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly CampaignBusinessRules _campaignBusinessRules;

        public GetDynamicCampaignsQueryHandler(IMapper mapper, ICampaignRepository campaignRepository, CampaignBusinessRules campaignBusinessRules)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _campaignBusinessRules = campaignBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicCampaignsResponse>> Handle(GetDynamicCampaignsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Campaign> campaign = await _campaignRepository.GetListByDynamicAsync(
               dynamic: request.DynamicQuery,
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);


            GetListResponse<GetDynamicCampaignsResponse> response = _mapper.Map<GetListResponse<GetDynamicCampaignsResponse>>(campaign);
            return response;
        }
    }
}
