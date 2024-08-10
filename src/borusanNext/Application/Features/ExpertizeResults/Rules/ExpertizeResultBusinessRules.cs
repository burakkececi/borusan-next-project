using Application.Features.ExpertizeResults.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.ExpertizeResults.Constants;

namespace Application.Features.ExpertizeResults.Rules;

public class ExpertizeResultBusinessRules : BaseBusinessRules
{
    private readonly IExpertizeResultRepository _expertizeResultRepository;
    private readonly IChassisPartRepository _chassisPartRepository;
    private readonly IBodyShellPartRepository _bodyShellPartRepository;
    private readonly ILocalizationService _localizationService;

    public ExpertizeResultBusinessRules(IExpertizeResultRepository expertizeResultRepository, ILocalizationService localizationService, IChassisPartRepository chassisPartRepository, IBodyShellPartRepository bodyShellPartRepository)
    {
        _expertizeResultRepository = expertizeResultRepository;
        _localizationService = localizationService;
        _chassisPartRepository = chassisPartRepository;
        _bodyShellPartRepository = bodyShellPartRepository;
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

    public async Task ChassisPartIdShouldExistWhenBindingToExpertizeResults(Guid id, CancellationToken cancellationToken)
    {
        ChassisPart? chassisPart = await _chassisPartRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );

        if (chassisPart == null)
            await throwBusinessException(ExpertizeResultsBusinessMessages.ChassisPartNotExists);
    }

    public async Task BodyShellPartIdShouldExistWhenBindingToExpertizeResults(Guid id, CancellationToken cancellationToken)
    {
        BodyShellPart? bodyShellPart = await _bodyShellPartRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );

        if (bodyShellPart == null)
            await throwBusinessException(ExpertizeResultsBusinessMessages.BodyShellPartNotExists);
    }
}