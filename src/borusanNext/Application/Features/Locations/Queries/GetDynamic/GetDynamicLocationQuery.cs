using Application.Features.Licences.Queries.GetDynamic;
using Application.Features.Locations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Queries.GetDynamic;
public class GetDynamicLocationQuery:IRequest<GetListResponse<GetDynamicLocaitonResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicLocationQueryHandler : IRequestHandler<GetDynamicLocationQuery, GetListResponse<GetDynamicLocaitonResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly LocationBusinessRules  _locationBusinessRules;

        public GetDynamicLocationQueryHandler(IMapper mapper, ILocationRepository locationRepository, LocationBusinessRules locationBusinessRules)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
            _locationBusinessRules = locationBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicLocaitonResponse>> Handle(GetDynamicLocationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Location> location = await _locationRepository.GetListByDynamicAsync(
            dynamic: request.DynamicQuery,
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);


            GetListResponse<GetDynamicLocaitonResponse> response = _mapper.Map<GetListResponse<GetDynamicLocaitonResponse>>(location);
            return response;
        }
    }
}
