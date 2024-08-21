using static Application.Features.BlogItemTags.Constants.BlogItemTagsOperationClaims;
using Application.Features.BlogItemTags.Queries.GetDynamic;
using Application.Features.BlogItemTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Brands.Queries.GetDynamic;

public class GetDynamicBlogItemQuery : IRequest<GetListResponse<GetDynamicBlogItemResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicBlogItemQueryHandler : IRequestHandler<GetDynamicBlogItemQuery, GetListResponse<GetDynamicBlogItemResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogItemTagRepository _blogItemTagRepository;
        private readonly BlogItemTagBusinessRules _blogItemTagBusinessRules;

        public GetDynamicBlogItemQueryHandler(IMapper mapper, IBlogItemTagRepository blogItemTagRepository, BlogItemTagBusinessRules blogItemTagBusinessRules)
        {
            _mapper = mapper;
            _blogItemTagRepository = blogItemTagRepository;
            _blogItemTagBusinessRules = blogItemTagBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicBlogItemResponse>> Handle(GetDynamicBlogItemQuery request, CancellationToken cancellationToken)
        {

            IPaginate<BlogItemTag> blogItemTag = await _blogItemTagRepository.GetListByDynamicAsync(
               dynamic: request.DynamicQuery,
               include: i => i.Include(blogItem=>blogItem.Blog).Include(blogItem=>blogItem.Tag),
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);


            GetListResponse<GetDynamicBlogItemResponse> response = _mapper.Map<GetListResponse<GetDynamicBlogItemResponse>>(blogItemTag);
            return response;
        }
    }
}
