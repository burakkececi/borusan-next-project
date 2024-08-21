using Application.Features.Engines.Queries.GetDynamic;
using Application.Features.ExpertizeResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.ExpertizeResults.Constants.ExpertizeResultsOperationClaims;


namespace Application.Features.ExpertizeResults.Queries.GetDynamic;
public class GetDynamicExpertizeResultQuery:IRequest<GetListResponse<GetDynamicExpertizeResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicExpertizeResultQueryHandler : IRequestHandler<GetDynamicExpertizeResultQuery, GetListResponse<GetDynamicExpertizeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IExpertizeResultRepository _expertizeResultRepository;
        private readonly ExpertizeResultBusinessRules _expertizeResultBusinessRules;

        public GetDynamicExpertizeResultQueryHandler(IMapper mapper, IExpertizeResultRepository expertizeResultRepository, ExpertizeResultBusinessRules expertizeResultBusinessRules)
        {
            _mapper = mapper;
            _expertizeResultRepository = expertizeResultRepository;
            _expertizeResultBusinessRules = expertizeResultBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicExpertizeResponse>> Handle(GetDynamicExpertizeResultQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ExpertizeResult> expertizeResult = await _expertizeResultRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                include: i => i.Include(e=>e.ChassisPart).Include(e=>e.BodyShellPart),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);


            GetListResponse<GetDynamicExpertizeResponse> response = _mapper.Map<GetListResponse<GetDynamicExpertizeResponse>>(expertizeResult);
            return response;
        }
    }
}
