using Application.Features.CustomerAdvertLogs.Constants;
using Application.Features.CustomerAdvertLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using Domain.Enums;
using static Application.Features.CustomerAdvertLogs.Constants.CustomerAdvertLogsOperationClaims;

namespace Application.Features.CustomerAdvertLogs.Commands.Update;

public class UpdateCustomerAdvertLogCommand : IRequest<UpdatedCustomerAdvertLogResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required Guid AdvertId { get; set; }
    public required CustomerContactInformation ContactStatus { get; set; }

    public string[] Roles => [Admin, Write, CustomerAdvertLogsOperationClaims.Update];

    public class UpdateCustomerAdvertLogCommandHandler : IRequestHandler<UpdateCustomerAdvertLogCommand, UpdatedCustomerAdvertLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAdvertLogRepository _customerAdvertLogRepository;
        private readonly CustomerAdvertLogBusinessRules _customerAdvertLogBusinessRules;

        public UpdateCustomerAdvertLogCommandHandler(IMapper mapper, ICustomerAdvertLogRepository customerAdvertLogRepository,
                                         CustomerAdvertLogBusinessRules customerAdvertLogBusinessRules)
        {
            _mapper = mapper;
            _customerAdvertLogRepository = customerAdvertLogRepository;
            _customerAdvertLogBusinessRules = customerAdvertLogBusinessRules;
        }

        public async Task<UpdatedCustomerAdvertLogResponse> Handle(UpdateCustomerAdvertLogCommand request, CancellationToken cancellationToken)
        {
            CustomerAdvertLog? customerAdvertLog = await _customerAdvertLogRepository.GetAsync(predicate: cal => cal.Id == request.Id, cancellationToken: cancellationToken);
            await _customerAdvertLogBusinessRules.CustomerAdvertLogShouldExistWhenSelected(customerAdvertLog);
            await _customerAdvertLogBusinessRules.CustomerIdShouldExistWhenSelected(request.CustomerId, cancellationToken);
            await _customerAdvertLogBusinessRules.AdvertIdShouldExistWhenSelected(request.AdvertId, cancellationToken);
           
            customerAdvertLog = _mapper.Map(request, customerAdvertLog);

            await _customerAdvertLogRepository.UpdateAsync(customerAdvertLog!);

            UpdatedCustomerAdvertLogResponse response = _mapper.Map<UpdatedCustomerAdvertLogResponse>(customerAdvertLog);
            return response;
        }
    }
}