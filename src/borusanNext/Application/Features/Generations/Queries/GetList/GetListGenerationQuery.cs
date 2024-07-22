using Application.Features.Generations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Generations.Constants.GenerationsOperationClaims;

namespace Application.Features.Generations.Queries.GetList;

public class GetListGenerationQuery : IRequest<GetListResponse<GetListGenerationListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListGenerationQueryHandler : IRequestHandler<GetListGenerationQuery, GetListResponse<GetListGenerationListItemDto>>
    {
        private readonly IGenerationRepository _generationRepository;
        private readonly IMapper _mapper;

        public GetListGenerationQueryHandler(IGenerationRepository generationRepository, IMapper mapper)
        {
            _generationRepository = generationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGenerationListItemDto>> Handle(GetListGenerationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Generation> generations = await _generationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGenerationListItemDto> response = _mapper.Map<GetListResponse<GetListGenerationListItemDto>>(generations);
            return response;
        }
    }
}