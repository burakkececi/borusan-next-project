using Application.Features.CustomerAdvertLogs.Constants;
using Application.Features.CustomerAdvertLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using Domain.Enums;
using static Application.Features.CustomerAdvertLogs.Constants.CustomerAdvertLogsOperationClaims;

namespace Application.Features.CustomerAdvertLogs.Commands.Create;

public class CreateCustomerAdvertLogCommand : IRequest<CreatedCustomerAdvertLogResponse>, ISecuredRequest
{
    public required Guid CustomerId { get; set; }
    public required Guid AdvertId { get; set; }
    public required CustomerContactInformation ContactStatus { get; set; }

    public string[] Roles => [Admin, Write, CustomerAdvertLogsOperationClaims.Create];

    public class CreateCustomerAdvertLogCommandHandler : IRequestHandler<CreateCustomerAdvertLogCommand, CreatedCustomerAdvertLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAdvertLogRepository _customerAdvertLogRepository;
        private readonly CustomerAdvertLogBusinessRules _customerAdvertLogBusinessRules;

        public CreateCustomerAdvertLogCommandHandler(IMapper mapper, ICustomerAdvertLogRepository customerAdvertLogRepository,
                                         CustomerAdvertLogBusinessRules customerAdvertLogBusinessRules)
        {
            _mapper = mapper;
            _customerAdvertLogRepository = customerAdvertLogRepository;
            _customerAdvertLogBusinessRules = customerAdvertLogBusinessRules;
        }

        public async Task<CreatedCustomerAdvertLogResponse> Handle(CreateCustomerAdvertLogCommand request, CancellationToken cancellationToken)
        {
            CustomerAdvertLog customerAdvertLog = _mapper.Map<CustomerAdvertLog>(request);

            await _customerAdvertLogBusinessRules.CustomerIdShouldExistWhenSelected(request.CustomerId, cancellationToken);
            await _customerAdvertLogBusinessRules.AdvertIdShouldExistWhenSelected(request.AdvertId, cancellationToken);

            await _customerAdvertLogRepository.AddAsync(customerAdvertLog);

            CreatedCustomerAdvertLogResponse response = _mapper.Map<CreatedCustomerAdvertLogResponse>(customerAdvertLog);
            return response;
        }
    }
}