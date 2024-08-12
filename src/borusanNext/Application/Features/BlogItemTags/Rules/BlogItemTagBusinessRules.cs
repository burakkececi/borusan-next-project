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
    private readonly ITagRepository _tagRepository; 
    private readonly IBlogRepository _blogRepository; 
    private readonly ILocalizationService _localizationService;

    public BlogItemTagBusinessRules(
        IBlogItemTagRepository blogItemTagRepository,
        ITagRepository tagRepository, 
        IBlogRepository blogRepository, 
        ILocalizationService localizationService
    )
    {
        _blogItemTagRepository = blogItemTagRepository;
        _tagRepository = tagRepository; 
        _blogRepository = blogRepository; 
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

    public async Task TagIdShouldExistWhenSelected(Guid tagId, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.GetAsync(
            predicate: t => t.Id == tagId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (tag == null)
        {
            string messageKey = BlogItemTagsBusinessMessages.TagNotExists; 
            await throwBusinessException(messageKey);
        }
    }
    public async Task BlogIdShouldExistWhenSelected(Guid blogId, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetAsync(
            predicate: b => b.Id == blogId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (blog == null)
        {
            string messageKey = BlogItemTagsBusinessMessages.BlogNotExists; 
            await throwBusinessException(messageKey);
        }
    }
}
