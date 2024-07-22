using Application.Features.BlogItemTags.Constants;
using Application.Features.BlogItemTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BlogItemTags.Constants.BlogItemTagsOperationClaims;

namespace Application.Features.BlogItemTags.Commands.Update;

public class UpdateBlogItemTagCommand : IRequest<UpdatedBlogItemTagResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required Guid TagId { get; set; }
    public required Guid BlogId { get; set; }

    public string[] Roles => [Admin, Write, BlogItemTagsOperationClaims.Update];

    public class UpdateBlogItemTagCommandHandler : IRequestHandler<UpdateBlogItemTagCommand, UpdatedBlogItemTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogItemTagRepository _blogItemTagRepository;
        private readonly BlogItemTagBusinessRules _blogItemTagBusinessRules;

        public UpdateBlogItemTagCommandHandler(IMapper mapper, IBlogItemTagRepository blogItemTagRepository,
                                         BlogItemTagBusinessRules blogItemTagBusinessRules)
        {
            _mapper = mapper;
            _blogItemTagRepository = blogItemTagRepository;
            _blogItemTagBusinessRules = blogItemTagBusinessRules;
        }

        public async Task<UpdatedBlogItemTagResponse> Handle(UpdateBlogItemTagCommand request, CancellationToken cancellationToken)
        {
            BlogItemTag? blogItemTag = await _blogItemTagRepository.GetAsync(predicate: bit => bit.Id == request.Id, cancellationToken: cancellationToken);
            await _blogItemTagBusinessRules.BlogItemTagShouldExistWhenSelected(blogItemTag);
            blogItemTag = _mapper.Map(request, blogItemTag);

            await _blogItemTagRepository.UpdateAsync(blogItemTag!);

            UpdatedBlogItemTagResponse response = _mapper.Map<UpdatedBlogItemTagResponse>(blogItemTag);
            return response;
        }
    }
}