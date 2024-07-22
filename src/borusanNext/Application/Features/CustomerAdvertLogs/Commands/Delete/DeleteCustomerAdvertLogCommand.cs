using Application.Features.CustomerAdvertLogs.Constants;
using Application.Features.CustomerAdvertLogs.Constants;
using Application.Features.CustomerAdvertLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerAdvertLogs.Constants.CustomerAdvertLogsOperationClaims;

namespace Application.Features.CustomerAdvertLogs.Commands.Delete;

public class DeleteCustomerAdvertLogCommand : IRequest<DeletedCustomerAdvertLogResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CustomerAdvertLogsOperationClaims.Delete];

    public class DeleteCustomerAdvertLogCommandHandler : IRequestHandler<DeleteCustomerAdvertLogCommand, DeletedCustomerAdvertLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAdvertLogRepository _customerAdvertLogRepository;
        private readonly CustomerAdvertLogBusinessRules _customerAdvertLogBusinessRules;

        public DeleteCustomerAdvertLogCommandHandler(IMapper mapper, ICustomerAdvertLogRepository customerAdvertLogRepository,
                                         CustomerAdvertLogBusinessRules customerAdvertLogBusinessRules)
        {
            _mapper = mapper;
            _customerAdvertLogRepository = customerAdvertLogRepository;
            _customerAdvertLogBusinessRules = customerAdvertLogBusinessRules;
        }

        public async Task<DeletedCustomerAdvertLogResponse> Handle(DeleteCustomerAdvertLogCommand request, CancellationToken cancellationToken)
        {
            CustomerAdvertLog? customerAdvertLog = await _customerAdvertLogRepository.GetAsync(predicate: cal => cal.Id == request.Id, cancellationToken: cancellationToken);
            await _customerAdvertLogBusinessRules.CustomerAdvertLogShouldExistWhenSelected(customerAdvertLog);

            await _customerAdvertLogRepository.DeleteAsync(customerAdvertLog!);

            DeletedCustomerAdvertLogResponse response = _mapper.Map<DeletedCustomerAdvertLogResponse>(customerAdvertLog);
            return response;
        }
    }
}