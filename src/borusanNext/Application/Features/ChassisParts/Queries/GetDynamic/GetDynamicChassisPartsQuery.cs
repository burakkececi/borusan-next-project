using Application.Features.CarModels.Queries.GetDynamic;
using Application.Features.ChassisParts.Queries.GetList;
using Application.Features.ChassisParts.Rules;
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

namespace Application.Features.ChassisParts.Queries.GetDynamic;
public class GetDynamicChassisPartsQuery:IRequest<GetListResponse<GetDynamicChassisPartsResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicChassisPartsQueryHandler : IRequestHandler<GetDynamicChassisPartsQuery, GetListResponse<GetDynamicChassisPartsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IChassisPartRepository _chassisPartRepository;
        private readonly ChassisPartBusinessRules _businessRules;

        public GetDynamicChassisPartsQueryHandler(IMapper mapper, IChassisPartRepository chassisPartRepository, ChassisPartBusinessRules businessRules)
        {
            _mapper = mapper;
            _chassisPartRepository = chassisPartRepository;
            _businessRules = businessRules;
        }

        public async Task<GetListResponse<GetDynamicChassisPartsResponse>> Handle(GetDynamicChassisPartsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ChassisPart> chassisPart = await _chassisPartRepository.GetListByDynamicAsync(
               dynamic: request.DynamicQuery,
               index: request.PageRequest.PageIndex,
               include: i => i.Include(c => c.ExpertizeResult),
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);


            GetListResponse<GetDynamicChassisPartsResponse> response = _mapper.Map<GetListResponse<GetDynamicChassisPartsResponse>>(chassisPart);
            return response;
        }
    }
}
