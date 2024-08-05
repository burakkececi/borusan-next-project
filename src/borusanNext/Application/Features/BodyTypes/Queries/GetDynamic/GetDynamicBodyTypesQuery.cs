using Application.Features.BodyShellParts.Queries.GetDynamic;
using Application.Features.BodyTypes.Rules;
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

namespace Application.Features.BodyTypes.Queries.GetDynamic;
public class GetDynamicBodyTypesQuery : IRequest<GetListResponse<GetDynamicBodyTypesResponse>>
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicBodyTypesQueryHandler : IRequestHandler<GetDynamicBodyTypesQuery, GetListResponse<GetDynamicBodyTypesResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly BodyTypeBusinessRules _bodyTypeBusinessRules;

        public GetDynamicBodyTypesQueryHandler(IMapper mapper, IBodyTypeRepository bodyTypeRepository, BodyTypeBusinessRules bodyTypeBusinessRules)
        {
            _mapper = mapper;
            _bodyTypeRepository = bodyTypeRepository;
            _bodyTypeBusinessRules = bodyTypeBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicBodyTypesResponse>> Handle(GetDynamicBodyTypesQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BodyType> bodyType = await _bodyTypeRepository.GetListByDynamicAsync(
              dynamic: request.DynamicQuery,
              include: i => i.Include(b=>b.Cars),
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken);


            GetListResponse<GetDynamicBodyTypesResponse> response = _mapper.Map<GetListResponse<GetDynamicBodyTypesResponse>>(bodyType);
            return response;
        }
    }
}
