using Application.Features.Sellers.Queries.GetDynamic;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Transmissions.Constants.TransmissionsOperationClaims;


namespace Application.Features.Transmissions.Queries.GetDynamic;
public class GetDynamicTransmissionQuery : IRequest<GetListResponse<GetDynamicTransmissionResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

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
