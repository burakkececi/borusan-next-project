using Application.Features.BodyShellParts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BodyShellParts.Constants.BodyShellPartsOperationClaims;

namespace Application.Features.BodyShellParts.Queries.GetList;

public class GetListBodyShellPartQuery : IRequest<GetListResponse<GetListBodyShellPartListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListBodyShellPartQueryHandler : IRequestHandler<GetListBodyShellPartQuery, GetListResponse<GetListBodyShellPartListItemDto>>
    {
        private readonly IBodyShellPartRepository _bodyShellPartRepository;
        private readonly IMapper _mapper;

        public GetListBodyShellPartQueryHandler(IBodyShellPartRepository bodyShellPartRepository, IMapper mapper)
        {
            _bodyShellPartRepository = bodyShellPartRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBodyShellPartListItemDto>> Handle(GetListBodyShellPartQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BodyShellPart> bodyShellParts = await _bodyShellPartRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBodyShellPartListItemDto> response = _mapper.Map<GetListResponse<GetListBodyShellPartListItemDto>>(bodyShellParts);
            return response;
        }
    }
}