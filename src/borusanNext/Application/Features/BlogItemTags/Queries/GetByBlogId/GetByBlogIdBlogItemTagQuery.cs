using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BlogItemTags.Constants.BlogItemTagsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BlogItemTags.Queries.GetList;

public class GetByBlogIdBlogItemTagQuery : IRequest<GetListResponse<GetByBlogIdBlogItemTagQueryResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Guid BlogId { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByBlogIdBlogItemTagQueryHandler : IRequestHandler<GetByBlogIdBlogItemTagQuery, GetListResponse<GetByBlogIdBlogItemTagQueryResponse>>
    {
        private readonly IBlogItemTagRepository _blogItemTagRepository;
        private readonly IMapper _mapper;

        public GetByBlogIdBlogItemTagQueryHandler(IBlogItemTagRepository blogItemTagRepository, IMapper mapper)
        {
            _blogItemTagRepository = blogItemTagRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetByBlogIdBlogItemTagQueryResponse>> Handle(GetByBlogIdBlogItemTagQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BlogItemTag> blogItemTags = await _blogItemTagRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                predicate: i => i.BlogId == request.BlogId,
                include: i => i.Include(blogItem => blogItem.Tag),
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetByBlogIdBlogItemTagQueryResponse> response = _mapper.Map<GetListResponse<GetByBlogIdBlogItemTagQueryResponse>>(blogItemTags);
            return response;
        }
    }
}