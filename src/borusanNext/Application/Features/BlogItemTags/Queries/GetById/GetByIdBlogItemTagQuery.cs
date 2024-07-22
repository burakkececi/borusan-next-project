using Application.Features.BlogItemTags.Constants;
using Application.Features.BlogItemTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BlogItemTags.Constants.BlogItemTagsOperationClaims;

namespace Application.Features.BlogItemTags.Queries.GetById;

public class GetByIdBlogItemTagQuery : IRequest<GetByIdBlogItemTagResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBlogItemTagQueryHandler : IRequestHandler<GetByIdBlogItemTagQuery, GetByIdBlogItemTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogItemTagRepository _blogItemTagRepository;
        private readonly BlogItemTagBusinessRules _blogItemTagBusinessRules;

        public GetByIdBlogItemTagQueryHandler(IMapper mapper, IBlogItemTagRepository blogItemTagRepository, BlogItemTagBusinessRules blogItemTagBusinessRules)
        {
            _mapper = mapper;
            _blogItemTagRepository = blogItemTagRepository;
            _blogItemTagBusinessRules = blogItemTagBusinessRules;
        }

        public async Task<GetByIdBlogItemTagResponse> Handle(GetByIdBlogItemTagQuery request, CancellationToken cancellationToken)
        {
            BlogItemTag? blogItemTag = await _blogItemTagRepository.GetAsync(predicate: bit => bit.Id == request.Id, cancellationToken: cancellationToken);
            await _blogItemTagBusinessRules.BlogItemTagShouldExistWhenSelected(blogItemTag);

            GetByIdBlogItemTagResponse response = _mapper.Map<GetByIdBlogItemTagResponse>(blogItemTag);
            return response;
        }
    }
}