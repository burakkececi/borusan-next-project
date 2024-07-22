using Application.Features.BlogItemTags.Commands.Create;
using Application.Features.BlogItemTags.Commands.Delete;
using Application.Features.BlogItemTags.Commands.Update;
using Application.Features.BlogItemTags.Queries.GetById;
using Application.Features.BlogItemTags.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BlogItemTags.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBlogItemTagCommand, BlogItemTag>();
        CreateMap<BlogItemTag, CreatedBlogItemTagResponse>();

        CreateMap<UpdateBlogItemTagCommand, BlogItemTag>();
        CreateMap<BlogItemTag, UpdatedBlogItemTagResponse>();

        CreateMap<DeleteBlogItemTagCommand, BlogItemTag>();
        CreateMap<BlogItemTag, DeletedBlogItemTagResponse>();

        CreateMap<BlogItemTag, GetByIdBlogItemTagResponse>();

        CreateMap<BlogItemTag, GetListBlogItemTagListItemDto>();
        CreateMap<IPaginate<BlogItemTag>, GetListResponse<GetListBlogItemTagListItemDto>>();
    }
}