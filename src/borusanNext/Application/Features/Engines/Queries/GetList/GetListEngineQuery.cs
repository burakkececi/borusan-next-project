using Application.Features.Engines.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Engines.Constants.EnginesOperationClaims;

namespace Application.Features.Engines.Queries.GetList;

public class GetListEngineQuery : IRequest<GetListResponse<GetListEngineListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListEngineQueryHandler : IRequestHandler<GetListEngineQuery, GetListResponse<GetListEngineListItemDto>>
    {
        private readonly IEngineRepository _engineRepository;
        private readonly IMapper _mapper;

        public GetListEngineQueryHandler(IEngineRepository engineRepository, IMapper mapper)
        {
            _engineRepository = engineRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEngineListItemDto>> Handle(GetListEngineQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Engine> engines = await _engineRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEngineListItemDto> response = _mapper.Map<GetListResponse<GetListEngineListItemDto>>(engines);
            return response;
        }
    }
}