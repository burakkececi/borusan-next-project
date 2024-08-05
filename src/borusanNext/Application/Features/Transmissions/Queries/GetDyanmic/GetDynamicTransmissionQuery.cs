using Application.Features.Sellers.Queries.GetDynamic;
using Application.Features.Transmissions.Rules;
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

namespace Application.Features.Transmissions.Queries.GetDyanmic;
public class GetDynamicTransmissionQuery:IRequest<GetListResponse<GetDynamicTransmissionResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicTransmissionQueryHandler : IRequestHandler<GetDynamicTransmissionQuery, GetListResponse<GetDynamicTransmissionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly TransmissionBusinessRules _businessRules;

        public GetDynamicTransmissionQueryHandler(IMapper mapper, ITransmissionRepository transmissionRepository, TransmissionBusinessRules businessRules)
        {
            _mapper = mapper;
            _transmissionRepository = transmissionRepository;
            _businessRules = businessRules;
        }

        public async Task<GetListResponse<GetDynamicTransmissionResponse>> Handle(GetDynamicTransmissionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Transmission> transmission = await _transmissionRepository.GetListByDynamicAsync(
            dynamic: request.DynamicQuery,
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);


            GetListResponse<GetDynamicTransmissionResponse> response = _mapper.Map<GetListResponse<GetDynamicTransmissionResponse>>(transmission);
            return response;
        }
    }
}
