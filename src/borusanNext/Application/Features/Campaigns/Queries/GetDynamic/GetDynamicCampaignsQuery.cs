using Application.Features.BlogItemTags.Queries.GetDynamic;
using Application.Features.Campaigns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Queries.GetDynamic;
public class GetDynamicCampaignsQuery:IRequest<GetListResponse<GetDynamicCampaignsResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
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
