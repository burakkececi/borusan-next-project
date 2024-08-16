using Application.Features.BlogItemTags.Queries.GetDynamic;
using Application.Features.BodyShellParts.Rules;
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

namespace Application.Features.BodyShellParts.Queries.GetDynamic;
public class GetDynamicBodyShellPartsQuery : IRequest<GetListResponse<GetDynamicBodyShellPartsResponse>>
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicBodyShellPartsQueryHandler : IRequestHandler<GetDynamicBodyShellPartsQuery, GetListResponse<GetDynamicBodyShellPartsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBodyShellPartRepository _bodyShellPartRepository;
        private readonly BodyShellPartBusinessRules _bodyShellPartBusinessRules;

        public GetDynamicBodyShellPartsQueryHandler(IMapper mapper, IBodyShellPartRepository bodyShellPartRepository, BodyShellPartBusinessRules bodyShellPartBusinessRules)
        {
            _mapper = mapper;
            _bodyShellPartRepository = bodyShellPartRepository;
            _bodyShellPartBusinessRules = bodyShellPartBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicBodyShellPartsResponse>> Handle(GetDynamicBodyShellPartsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BodyShellPart> bodyShellPart = await _bodyShellPartRepository.GetListByDynamicAsync(
               dynamic: request.DynamicQuery,
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);


            GetListResponse<GetDynamicBodyShellPartsResponse> response = _mapper.Map<GetListResponse<GetDynamicBodyShellPartsResponse>>(bodyShellPart);
            return response;
        }
    }
}
