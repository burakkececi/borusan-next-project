using Application.Features.BodyShellParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.BodyShellParts.Constants.BodyShellPartsOperationClaims;


namespace Application.Features.BodyShellParts.Queries.GetDynamic;
public class GetDynamicBodyShellPartsQuery : IRequest<GetListResponse<GetDynamicBodyShellPartsResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicBodyShellPartsQueryHandler : IRequestHandler<GetDynamicBodyShellPartsQuery, GetListResponse<GetDynamicBodyShellPartsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBodyShellPartRepository _bodyShellPartRepository;
        private readonly BodyShellPartBusinessRules _bodyShellPartBusinessRules;

        public GetDynamicBodyShellPartsQueryHandler(IMapper mapper, IBodyShellPartRepository bodyShellPartRepository, BodyShellPartBusinessRules bodyShellPartBusinessRules)
        {
            _mapper = mapper;
            _bodyShellPartRepository = bodyShellPartRepository;
            _bodyShellPartBusinessRules = bodyShellPartBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicBodyShellPartsResponse>> Handle(GetDynamicBodyShellPartsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BodyShellPart> bodyShellPart = await _bodyShellPartRepository.GetListByDynamicAsync(
               dynamic: request.DynamicQuery,
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);


            GetListResponse<GetDynamicBodyShellPartsResponse> response = _mapper.Map<GetListResponse<GetDynamicBodyShellPartsResponse>>(bodyShellPart);
            return response;
        }
    }
}
