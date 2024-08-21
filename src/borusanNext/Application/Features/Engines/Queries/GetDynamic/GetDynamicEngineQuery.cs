using Application.Features.CarModels.Queries.GetDynamic;
using Application.Features.Engines.Rules;
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
using static Application.Features.Engines.Constants.EnginesOperationClaims;


namespace Application.Features.Engines.Queries.GetDynamic;
public class GetDynamicEngineQuery : IRequest<GetListResponse<GetDynamicEngineResponse>>, ISecuredRequest
{
    public PageRequest  PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicEngineQueryHandler : IRequestHandler<GetDynamicEngineQuery, GetListResponse<GetDynamicEngineResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEngineRepository _engineRepository;
        private readonly EngineBusinessRules _businessRules;

        public GetDynamicEngineQueryHandler(IMapper mapper, IEngineRepository engineRepository, EngineBusinessRules businessRules)
        {
            _mapper = mapper;
            _engineRepository = engineRepository;
            _businessRules = businessRules;
        }

        public async Task<GetListResponse<GetDynamicEngineResponse>> Handle(GetDynamicEngineQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Engine> engine = await _engineRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                include: i => i.Include(e=>e.FuelType),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);


            GetListResponse<GetDynamicEngineResponse> response = _mapper.Map<GetListResponse<GetDynamicEngineResponse>>(engine);
            return response;
        }
    }
}
