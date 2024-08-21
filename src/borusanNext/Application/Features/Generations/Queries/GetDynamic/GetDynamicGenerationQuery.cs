using Application.Features.FuelTypes.Queries.GetDynamic;
using Application.Features.Generations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Generations.Constants.GenerationsOperationClaims;


namespace Application.Features.Generations.Queries.GetDynamic;
public class GetDynamicGenerationQuery:IRequest<GetListResponse<GetDynamicGenerationResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicGenerationQueryHandler : IRequestHandler<GetDynamicGenerationQuery, GetListResponse<GetDynamicGenerationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationRepository _generationRepository;
        private readonly GenerationBusinessRules    _businessRules;

        public GetDynamicGenerationQueryHandler(IMapper mapper, IGenerationRepository generationRepository, GenerationBusinessRules businessRules)
        {
            _mapper = mapper;
            _generationRepository = generationRepository;
            _businessRules = businessRules;
        }

        public async Task<GetListResponse<GetDynamicGenerationResponse>> Handle(GetDynamicGenerationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Generation> generation = await _generationRepository.GetListByDynamicAsync(
              dynamic: request.DynamicQuery,
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken);


            GetListResponse<GetDynamicGenerationResponse> response = _mapper.Map<GetListResponse<GetDynamicGenerationResponse>>(generation);
            return response;
        }
    }
}
