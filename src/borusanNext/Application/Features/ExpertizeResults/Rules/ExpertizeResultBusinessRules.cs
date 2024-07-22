using Application.Features.ExpertizeResults.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ExpertizeResults.Rules;

public class ExpertizeResultBusinessRules : BaseBusinessRules
{
    private readonly IExpertizeResultRepository _expertizeResultRepository;
    private readonly ILocalizationService _localizationService;

    public ExpertizeResultBusinessRules(IExpertizeResultRepository expertizeResultRepository, ILocalizationService localizationService)
    {
        _expertizeResultRepository = expertizeResultRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ExpertizeResultsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ExpertizeResultShouldExistWhenSelected(ExpertizeResult? expertizeResult)
    {
        if (expertizeResult == null)
            await throwBusinessException(ExpertizeResultsBusinessMessages.ExpertizeResultNotExists);
    }

    public async Task ExpertizeResultIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ExpertizeResult? expertizeResult = await _expertizeResultRepository.GetAsync(
            predicate: er => er.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ExpertizeResultShouldExistWhenSelected(expertizeResult);
    }
}