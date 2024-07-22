using Application.Features.BodyShellParts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BodyShellParts.Rules;

public class BodyShellPartBusinessRules : BaseBusinessRules
{
    private readonly IBodyShellPartRepository _bodyShellPartRepository;
    private readonly ILocalizationService _localizationService;

    public BodyShellPartBusinessRules(IBodyShellPartRepository bodyShellPartRepository, ILocalizationService localizationService)
    {
        _bodyShellPartRepository = bodyShellPartRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BodyShellPartsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BodyShellPartShouldExistWhenSelected(BodyShellPart? bodyShellPart)
    {
        if (bodyShellPart == null)
            await throwBusinessException(BodyShellPartsBusinessMessages.BodyShellPartNotExists);
    }

    public async Task BodyShellPartIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BodyShellPart? bodyShellPart = await _bodyShellPartRepository.GetAsync(
            predicate: bsp => bsp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BodyShellPartShouldExistWhenSelected(bodyShellPart);
    }
}