using Application.Features.CustomerAdvertLogs.Constants;
using Application.Features.CustomerAdvertLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerAdvertLogs.Constants.CustomerAdvertLogsOperationClaims;

namespace Application.Features.CustomerAdvertLogs.Queries.GetById;

public class GetByIdCustomerAdvertLogQuery : IRequest<GetByIdCustomerAdvertLogResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCustomerAdvertLogQueryHandler : IRequestHandler<GetByIdCustomerAdvertLogQuery, GetByIdCustomerAdvertLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAdvertLogRepository _customerAdvertLogRepository;
        private readonly CustomerAdvertLogBusinessRules _customerAdvertLogBusinessRules;

        public GetByIdCustomerAdvertLogQueryHandler(IMapper mapper, ICustomerAdvertLogRepository customerAdvertLogRepository, CustomerAdvertLogBusinessRules customerAdvertLogBusinessRules)
        {
            _mapper = mapper;
            _customerAdvertLogRepository = customerAdvertLogRepository;
            _customerAdvertLogBusinessRules = customerAdvertLogBusinessRules;
        }

        public async Task<GetByIdCustomerAdvertLogResponse> Handle(GetByIdCustomerAdvertLogQuery request, CancellationToken cancellationToken)
        {
            CustomerAdvertLog? customerAdvertLog = await _customerAdvertLogRepository.GetAsync(predicate: cal => cal.Id == request.Id, cancellationToken: cancellationToken);
            await _customerAdvertLogBusinessRules.CustomerAdvertLogShouldExistWhenSelected(customerAdvertLog);

            GetByIdCustomerAdvertLogResponse response = _mapper.Map<GetByIdCustomerAdvertLogResponse>(customerAdvertLog);
            return response;
        }
    }
}