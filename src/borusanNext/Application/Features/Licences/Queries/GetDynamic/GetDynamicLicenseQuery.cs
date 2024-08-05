using Application.Features.Generations.Queries.GetDynamic;
using Application.Features.Licences.Rules;
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

namespace Application.Features.Licences.Queries.GetDynamic;
public class GetDynamicLicenseQuery:IRequest<GetListResponse<GetDynamicLicenceResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicLicenseQueryHandler : IRequestHandler<GetDynamicLicenseQuery, GetListResponse<GetDynamicLicenceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILicenceRepository _licenceRepository;
        private readonly LicenceBusinessRules _businessRules;

        public GetDynamicLicenseQueryHandler(IMapper mapper, ILicenceRepository licenceRepository, LicenceBusinessRules businessRules)
        {
            _mapper = mapper;
            _licenceRepository = licenceRepository;
            _businessRules = businessRules;
        }

        public async Task<GetListResponse<GetDynamicLicenceResponse>> Handle(GetDynamicLicenseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Licence> licence = await _licenceRepository.GetListByDynamicAsync(
             dynamic: request.DynamicQuery,
             index: request.PageRequest.PageIndex,
             size: request.PageRequest.PageSize,
             cancellationToken: cancellationToken);


            GetListResponse<GetDynamicLicenceResponse> response = _mapper.Map<GetListResponse<GetDynamicLicenceResponse>>(licence);
            return response;
        }
    }
}
