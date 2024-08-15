using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Brands.Queries.GetDynamic;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBrandCommand, Brand>();
        CreateMap<Brand, CreatedBrandResponse>();

        CreateMap<UpdateBrandCommand, Brand>();
        CreateMap<Brand, UpdatedBrandResponse>();

        CreateMap<DeleteBrandCommand, Brand>();
        CreateMap<Brand, DeletedBrandResponse>();

        CreateMap<Brand, GetByIdBrandResponse>();

        CreateMap<Brand, GetListBrandListItemDto>();
        CreateMap<IPaginate<Brand>, GetListResponse<GetListBrandListItemDto>>();
        CreateMap<Brand, GetDynamicBrandResponse>().ReverseMap();
        CreateMap<IPaginate<Brand>, GetListResponse<GetDynamicBrandResponse>>().ReverseMap();
    }
}