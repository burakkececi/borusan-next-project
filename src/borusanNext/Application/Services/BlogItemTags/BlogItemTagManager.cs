using Application.Features.BlogItemTags.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BlogItemTags;

public class BlogItemTagManager : IBlogItemTagService
{
    private readonly IBlogItemTagRepository _blogItemTagRepository;
    private readonly BlogItemTagBusinessRules _blogItemTagBusinessRules;

    public BlogItemTagManager(IBlogItemTagRepository blogItemTagRepository, BlogItemTagBusinessRules blogItemTagBusinessRules)
    {
        _blogItemTagRepository = blogItemTagRepository;
        _blogItemTagBusinessRules = blogItemTagBusinessRules;
    }

    public async Task<BlogItemTag?> GetAsync(
        Expression<Func<BlogItemTag, bool>> predicate,
        Func<IQueryable<BlogItemTag>, IIncludableQueryable<BlogItemTag, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BlogItemTag? blogItemTag = await _blogItemTagRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return blogItemTag;
    }

    public async Task<IPaginate<BlogItemTag>?> GetListAsync(
        Expression<Func<BlogItemTag, bool>>? predicate = null,
        Func<IQueryable<BlogItemTag>, IOrderedQueryable<BlogItemTag>>? orderBy = null,
        Func<IQueryable<BlogItemTag>, IIncludableQueryable<BlogItemTag, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BlogItemTag> blogItemTagList = await _blogItemTagRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return blogItemTagList;
    }

    public async Task<BlogItemTag> AddAsync(BlogItemTag blogItemTag)
    {
        BlogItemTag addedBlogItemTag = await _blogItemTagRepository.AddAsync(blogItemTag);

        return addedBlogItemTag;
    }

    public async Task<BlogItemTag> UpdateAsync(BlogItemTag blogItemTag)
    {
        BlogItemTag updatedBlogItemTag = await _blogItemTagRepository.UpdateAsync(blogItemTag);

        return updatedBlogItemTag;
    }

    public async Task<BlogItemTag> DeleteAsync(BlogItemTag blogItemTag, bool permanent = false)
    {
        BlogItemTag deletedBlogItemTag = await _blogItemTagRepository.DeleteAsync(blogItemTag);

        return deletedBlogItemTag;
    }
}
