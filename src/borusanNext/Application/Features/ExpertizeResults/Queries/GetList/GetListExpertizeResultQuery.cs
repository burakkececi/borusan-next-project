using Application.Features.ExpertizeResults.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ExpertizeResults.Constants.ExpertizeResultsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ExpertizeResults.Queries.GetList;

public class GetListExpertizeResultQuery : IRequest<GetListResponse<GetListExpertizeResultListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListExpertizeResultQueryHandler : IRequestHandler<GetListExpertizeResultQuery, GetListResponse<GetListExpertizeResultListItemDto>>
    {
        private readonly IExpertizeResultRepository _expertizeResultRepository;
        private readonly IMapper _mapper;

        public GetListExpertizeResultQueryHandler(IExpertizeResultRepository expertizeResultRepository, IMapper mapper)
        {
            _expertizeResultRepository = expertizeResultRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListExpertizeResultListItemDto>> Handle(GetListExpertizeResultQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ExpertizeResult> expertizeResults = await _expertizeResultRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: i => i.Include(e => e.ChassisPart).Include(e => e.BodyShellPart),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListExpertizeResultListItemDto> response = _mapper.Map<GetListResponse<GetListExpertizeResultListItemDto>>(expertizeResults);
            return response;
        }
    }
}