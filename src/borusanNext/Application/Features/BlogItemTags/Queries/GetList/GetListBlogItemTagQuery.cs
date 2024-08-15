using Application.Features.BlogItemTags.Constants;
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

public class GetListBlogItemTagQuery : IRequest<GetListResponse<GetListBlogItemTagListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListBlogItemTagQueryHandler : IRequestHandler<GetListBlogItemTagQuery, GetListResponse<GetListBlogItemTagListItemDto>>
    {
        private readonly IBlogItemTagRepository _blogItemTagRepository;
        private readonly IMapper _mapper;

        public GetListBlogItemTagQueryHandler(IBlogItemTagRepository blogItemTagRepository, IMapper mapper)
        {
            _blogItemTagRepository = blogItemTagRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBlogItemTagListItemDto>> Handle(GetListBlogItemTagQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BlogItemTag> blogItemTags = await _blogItemTagRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                include: i => i.Include(blogItem => blogItem.Blog).Include(blogItem => blogItem.Tag),
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBlogItemTagListItemDto> response = _mapper.Map<GetListResponse<GetListBlogItemTagListItemDto>>(blogItemTags);
            return response;
        }
    }
}