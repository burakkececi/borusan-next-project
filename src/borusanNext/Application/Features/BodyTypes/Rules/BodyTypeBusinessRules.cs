using Application.Features.BodyTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BodyTypes.Rules;

public class BodyTypeBusinessRules : BaseBusinessRules
{
    private readonly IBodyTypeRepository _bodyTypeRepository;
    private readonly ILocalizationService _localizationService;

    public BodyTypeBusinessRules(IBodyTypeRepository bodyTypeRepository, ILocalizationService localizationService)
    {
        _bodyTypeRepository = bodyTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BodyTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BodyTypeShouldExistWhenSelected(BodyType? bodyType)
    {
        if (bodyType == null)
            await throwBusinessException(BodyTypesBusinessMessages.BodyTypeNotExists);
    }

    public async Task BodyTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BodyType? bodyType = await _bodyTypeRepository.GetAsync(
            predicate: bt => bt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BodyTypeShouldExistWhenSelected(bodyType);
    }
}