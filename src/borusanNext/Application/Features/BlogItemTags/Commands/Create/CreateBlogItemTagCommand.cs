using Application.Features.BlogItemTags.Constants;
using Application.Features.BlogItemTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BlogItemTags.Constants.BlogItemTagsOperationClaims;

namespace Application.Features.BlogItemTags.Commands.Create;

public class CreateBlogItemTagCommand : IRequest<CreatedBlogItemTagResponse>, ISecuredRequest
{
    public required Guid TagId { get; set; }
    public required Guid BlogId { get; set; }

    public string[] Roles => [Admin, Write, BlogItemTagsOperationClaims.Create];

    public class CreateBlogItemTagCommandHandler : IRequestHandler<CreateBlogItemTagCommand, CreatedBlogItemTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogItemTagRepository _blogItemTagRepository;
        private readonly BlogItemTagBusinessRules _blogItemTagBusinessRules;

        public CreateBlogItemTagCommandHandler(IMapper mapper, IBlogItemTagRepository blogItemTagRepository,
                                         BlogItemTagBusinessRules blogItemTagBusinessRules)
        {
            _mapper = mapper;
            _blogItemTagRepository = blogItemTagRepository;
            _blogItemTagBusinessRules = blogItemTagBusinessRules;
        }

        public async Task<CreatedBlogItemTagResponse> Handle(CreateBlogItemTagCommand request, CancellationToken cancellationToken)
        {
            BlogItemTag blogItemTag = _mapper.Map<BlogItemTag>(request);

            await _blogItemTagRepository.AddAsync(blogItemTag);

            CreatedBlogItemTagResponse response = _mapper.Map<CreatedBlogItemTagResponse>(blogItemTag);
            return response;
        }
    }
}