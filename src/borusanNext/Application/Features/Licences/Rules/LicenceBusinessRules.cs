using Application.Features.Licences.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Licences.Rules;

public class LicenceBusinessRules : BaseBusinessRules
{
    private readonly ILicenceRepository _licenceRepository;
    private readonly ILocalizationService _localizationService;

    public LicenceBusinessRules(ILicenceRepository licenceRepository, ILocalizationService localizationService)
    {
        _licenceRepository = licenceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LicencesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LicenceShouldExistWhenSelected(Licence? licence)
    {
        if (licence == null)
            await throwBusinessException(LicencesBusinessMessages.LicenceNotExists);
    }

    public async Task LicenceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Licence? licence = await _licenceRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LicenceShouldExistWhenSelected(licence);
    }
}