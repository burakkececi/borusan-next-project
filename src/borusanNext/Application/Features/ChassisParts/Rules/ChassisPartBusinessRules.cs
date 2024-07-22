using Application.Features.ChassisParts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ChassisParts.Rules;

public class ChassisPartBusinessRules : BaseBusinessRules
{
    private readonly IChassisPartRepository _chassisPartRepository;
    private readonly ILocalizationService _localizationService;

    public ChassisPartBusinessRules(IChassisPartRepository chassisPartRepository, ILocalizationService localizationService)
    {
        _chassisPartRepository = chassisPartRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ChassisPartsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ChassisPartShouldExistWhenSelected(ChassisPart? chassisPart)
    {
        if (chassisPart == null)
            await throwBusinessException(ChassisPartsBusinessMessages.ChassisPartNotExists);
    }

    public async Task ChassisPartIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ChassisPart? chassisPart = await _chassisPartRepository.GetAsync(
            predicate: cp => cp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ChassisPartShouldExistWhenSelected(chassisPart);
    }
}