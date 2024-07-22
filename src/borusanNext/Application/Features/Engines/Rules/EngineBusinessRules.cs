using Application.Features.Engines.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Engines.Rules;

public class EngineBusinessRules : BaseBusinessRules
{
    private readonly IEngineRepository _engineRepository;
    private readonly ILocalizationService _localizationService;

    public EngineBusinessRules(IEngineRepository engineRepository, ILocalizationService localizationService)
    {
        _engineRepository = engineRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EnginesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EngineShouldExistWhenSelected(Engine? engine)
    {
        if (engine == null)
            await throwBusinessException(EnginesBusinessMessages.EngineNotExists);
    }

    public async Task EngineIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Engine? engine = await _engineRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EngineShouldExistWhenSelected(engine);
    }
}