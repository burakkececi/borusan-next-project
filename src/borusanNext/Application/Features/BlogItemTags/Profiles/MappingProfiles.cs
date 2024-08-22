using Application.Features.BlogItemTags.Commands.Create;
using Application.Features.BlogItemTags.Commands.Delete;
using Application.Features.BlogItemTags.Commands.Update;
using Application.Features.BlogItemTags.Queries.GetById;
using Application.Features.BlogItemTags.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.BlogItemTags.Queries.GetDynamic;

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

        CreateMap<BlogItemTag, GetByIdBlogItemTagResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Tag.Id))
            .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Tag.Name))
            .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.Blog.Id))
            .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title))
            .ForMember(dest => dest.BlogDescription, opt => opt.MapFrom(src => src.Blog.Description))
            .ForMember(dest => dest.BlogBanner, opt => opt.MapFrom(src => src.Blog.Banner));

        CreateMap<BlogItemTag, GetListBlogItemTagListItemDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Tag.Id))
            .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Tag.Name))
            .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.Blog.Id))
            .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title))
            .ForMember(dest => dest.BlogDescription, opt => opt.MapFrom(src => src.Blog.Description))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.Blog.CreatedDate));

        CreateMap<IPaginate<BlogItemTag>, GetListResponse<GetListBlogItemTagListItemDto>>();
        CreateMap<BlogItemTag, GetDynamicBlogItemResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Tag.Id))
            .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Tag.Name))
            .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.Blog.Id))
            .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title))
            .ForMember(dest => dest.BlogDescription, opt => opt.MapFrom(src => src.Blog.Description))
            .ForMember(dest => dest.BlogBanner, opt => opt.MapFrom(src => src.Blog.Banner))
            ;
        CreateMap<IPaginate<BlogItemTag>, GetListResponse<GetDynamicBlogItemResponse>>();

        CreateMap<BlogItemTag, GetByBlogIdBlogItemTagQueryResponse>()
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag.Name));
        CreateMap<IPaginate<BlogItemTag>, GetListResponse<GetByBlogIdBlogItemTagQueryResponse>>();

    }
}