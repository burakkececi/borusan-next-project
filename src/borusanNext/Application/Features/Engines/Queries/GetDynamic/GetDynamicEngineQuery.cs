using Application.Features.CarModels.Queries.GetDynamic;
using Application.Features.Engines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Engines.Queries.GetDynamic;
public class GetDynamicEngineQuery:IRequest<GetListResponse<GetDynamicChassisPartResponse>>
{
    public PageRequest  PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicEngineQueryHandler : IRequestHandler<GetDynamicEngineQuery, GetListResponse<GetDynamicChassisPartResponse>>
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

        public async Task<GetListResponse<GetDynamicChassisPartResponse>> Handle(GetDynamicEngineQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Engine> engine = await _engineRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                include: i => i.Include(e=>e.FuelType).Include(e=>e.FuelConsumption),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);


            GetListResponse<GetDynamicChassisPartResponse> response = _mapper.Map<GetListResponse<GetDynamicChassisPartResponse>>(engine);
            return response;
        }
    }
}
