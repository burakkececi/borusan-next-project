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
    private readonly ICustomerRepository _customerRepository; 
    private readonly IAdvertRepository _advertRepository;     
    private readonly ILocalizationService _localizationService;

    public CustomerAdvertLogBusinessRules(
        ICustomerAdvertLogRepository customerAdvertLogRepository,
        ICustomerRepository customerRepository, 
        IAdvertRepository advertRepository,     
        ILocalizationService localizationService
    )
    {
        _customerAdvertLogRepository = customerAdvertLogRepository;
        _customerRepository = customerRepository; 
        _advertRepository = advertRepository;     
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

    public async Task CustomerIdShouldExistWhenSelected(Guid customerId, CancellationToken cancellationToken)
    {
        Customer? customer = await _customerRepository.GetAsync(
            predicate: c => c.Id == customerId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (customer == null)
        {
            await throwBusinessException(CustomerAdvertLogsBusinessMessages.CustomerNotExists); 
        }
    }

    public async Task AdvertIdShouldExistWhenSelected(Guid advertId, CancellationToken cancellationToken)
    {
        Advert? advert = await _advertRepository.GetAsync(
            predicate: a => a.Id == advertId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (advert == null)
        {
            await throwBusinessException(CustomerAdvertLogsBusinessMessages.AdvertNotExists); 
        }
    }
}
