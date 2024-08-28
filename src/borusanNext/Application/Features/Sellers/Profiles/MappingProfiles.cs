using Application.Features.Sellers.Commands.Create;
using Application.Features.Sellers.Commands.Delete;
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Queries.GetById;
using Application.Features.Sellers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Sellers.Queries.GetDynamic;

namespace Application.Features.Sellers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSellerCommand, Seller>();
        CreateMap<Seller, CreatedSellerResponse>();

        CreateMap<UpdateSellerCommand, Seller>();
        CreateMap<Seller, UpdatedSellerResponse>();

        CreateMap<DeleteSellerCommand, Seller>();
        CreateMap<Seller, DeletedSellerResponse>();

        CreateMap<Seller, GetByIdSellerResponse>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));

        CreateMap<Seller, GetListSellerListItemDto>()
                        .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));
        CreateMap<IPaginate<Seller>, GetListResponse<GetListSellerListItemDto>>();
        CreateMap<Seller, GetDynamicSellerResponse>()
                        .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));
        CreateMap<IPaginate<Seller>, GetListResponse<GetDynamicSellerResponse>>();
    }
}