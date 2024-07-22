using Application.Features.CustomerAdvertLogs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CustomerAdvertLogs.Rules;

public class CustomerAdvertLogBusinessRules : BaseBusinessRules
{
    private readonly ICustomerAdvertLogRepository _customerAdvertLogRepository;
    private readonly ILocalizationService _localizationService;

    public CustomerAdvertLogBusinessRules(ICustomerAdvertLogRepository customerAdvertLogRepository, ILocalizationService localizationService)
    {
        _customerAdvertLogRepository = customerAdvertLogRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CustomerAdvertLogsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CustomerAdvertLogShouldExistWhenSelected(CustomerAdvertLog? customerAdvertLog)
    {
        if (customerAdvertLog == null)
            await throwBusinessException(CustomerAdvertLogsBusinessMessages.CustomerAdvertLogNotExists);
    }

    public async Task CustomerAdvertLogIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CustomerAdvertLog? customerAdvertLog = await _customerAdvertLogRepository.GetAsync(
            predicate: cal => cal.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerAdvertLogShouldExistWhenSelected(customerAdvertLog);
    }
}