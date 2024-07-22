using Application.Features.Tags.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Tags.Rules;

public class TagBusinessRules : BaseBusinessRules
{
    private readonly ITagRepository _tagRepository;
    private readonly ILocalizationService _localizationService;

    public TagBusinessRules(ITagRepository tagRepository, ILocalizationService localizationService)
    {
        _tagRepository = tagRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TagsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TagShouldExistWhenSelected(Tag? tag)
    {
        if (tag == null)
            await throwBusinessException(TagsBusinessMessages.TagNotExists);
    }

    public async Task TagIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Tag? tag = await _tagRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TagShouldExistWhenSelected(tag);
    }
}