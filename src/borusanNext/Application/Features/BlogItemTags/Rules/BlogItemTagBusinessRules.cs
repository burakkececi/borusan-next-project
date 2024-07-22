using Application.Features.BlogItemTags.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BlogItemTags.Rules;

public class BlogItemTagBusinessRules : BaseBusinessRules
{
    private readonly IBlogItemTagRepository _blogItemTagRepository;
    private readonly ILocalizationService _localizationService;

    public BlogItemTagBusinessRules(IBlogItemTagRepository blogItemTagRepository, ILocalizationService localizationService)
    {
        _blogItemTagRepository = blogItemTagRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BlogItemTagsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BlogItemTagShouldExistWhenSelected(BlogItemTag? blogItemTag)
    {
        if (blogItemTag == null)
            await throwBusinessException(BlogItemTagsBusinessMessages.BlogItemTagNotExists);
    }

    public async Task BlogItemTagIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BlogItemTag? blogItemTag = await _blogItemTagRepository.GetAsync(
            predicate: bit => bit.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BlogItemTagShouldExistWhenSelected(blogItemTag);
    }
}