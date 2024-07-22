using Application.Features.Blogs.Constants;
using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Blogs.Constants.BlogsOperationClaims;

namespace Application.Features.Blogs.Commands.Update;

public class UpdateBlogCommand : IRequest<UpdatedBlogResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedDate { get; set; }

    public string[] Roles => [Admin, Write, BlogsOperationClaims.Update];

    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, UpdatedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;

        public UpdateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<UpdatedBlogResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _blogBusinessRules.BlogShouldExistWhenSelected(blog);
            blog = _mapper.Map(request, blog);

            await _blogRepository.UpdateAsync(blog!);

            UpdatedBlogResponse response = _mapper.Map<UpdatedBlogResponse>(blog);
            return response;
        }
    }
}