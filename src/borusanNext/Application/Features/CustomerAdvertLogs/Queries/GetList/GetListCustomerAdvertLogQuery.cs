using Application.Features.CustomerAdvertLogs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerAdvertLogs.Constants.CustomerAdvertLogsOperationClaims;

namespace Application.Features.CustomerAdvertLogs.Queries.GetList;

public class GetListCustomerAdvertLogQuery : IRequest<GetListResponse<GetListCustomerAdvertLogListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListCustomerAdvertLogQueryHandler : IRequestHandler<GetListCustomerAdvertLogQuery, GetListResponse<GetListCustomerAdvertLogListItemDto>>
    {
        private readonly ICustomerAdvertLogRepository _customerAdvertLogRepository;
        private readonly IMapper _mapper;

        public GetListCustomerAdvertLogQueryHandler(ICustomerAdvertLogRepository customerAdvertLogRepository, IMapper mapper)
        {
            _customerAdvertLogRepository = customerAdvertLogRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerAdvertLogListItemDto>> Handle(GetListCustomerAdvertLogQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerAdvertLog> customerAdvertLogs = await _customerAdvertLogRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerAdvertLogListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerAdvertLogListItemDto>>(customerAdvertLogs);
            return response;
        }
    }
}