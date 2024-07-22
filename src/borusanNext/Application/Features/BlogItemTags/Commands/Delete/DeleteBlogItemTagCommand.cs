using Application.Features.BlogItemTags.Constants;
using Application.Features.BlogItemTags.Constants;
using Application.Features.BlogItemTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BlogItemTags.Constants.BlogItemTagsOperationClaims;

namespace Application.Features.BlogItemTags.Commands.Delete;

public class DeleteBlogItemTagCommand : IRequest<DeletedBlogItemTagResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BlogItemTagsOperationClaims.Delete];

    public class DeleteBlogItemTagCommandHandler : IRequestHandler<DeleteBlogItemTagCommand, DeletedBlogItemTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogItemTagRepository _blogItemTagRepository;
        private readonly BlogItemTagBusinessRules _blogItemTagBusinessRules;

        public DeleteBlogItemTagCommandHandler(IMapper mapper, IBlogItemTagRepository blogItemTagRepository,
                                         BlogItemTagBusinessRules blogItemTagBusinessRules)
        {
            _mapper = mapper;
            _blogItemTagRepository = blogItemTagRepository;
            _blogItemTagBusinessRules = blogItemTagBusinessRules;
        }

        public async Task<DeletedBlogItemTagResponse> Handle(DeleteBlogItemTagCommand request, CancellationToken cancellationToken)
        {
            BlogItemTag? blogItemTag = await _blogItemTagRepository.GetAsync(predicate: bit => bit.Id == request.Id, cancellationToken: cancellationToken);
            await _blogItemTagBusinessRules.BlogItemTagShouldExistWhenSelected(blogItemTag);

            await _blogItemTagRepository.DeleteAsync(blogItemTag!);

            DeletedBlogItemTagResponse response = _mapper.Map<DeletedBlogItemTagResponse>(blogItemTag);
            return response;
        }
    }
}