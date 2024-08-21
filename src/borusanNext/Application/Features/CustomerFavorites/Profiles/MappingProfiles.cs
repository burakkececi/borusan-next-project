using Application.Features.CustomerFavorites.Commands.Create;
using Application.Features.CustomerFavorites.Commands.Delete;
using Application.Features.CustomerFavorites.Commands.Update;
using Application.Features.CustomerFavorites.Queries.GetById;
using Application.Features.CustomerFavorites.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.CustomerFavorites.Queries.GetByCustomerId;

namespace Application.Features.CustomerFavorites.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomerFavoriteCommand, CustomerFavorite>();
        CreateMap<CustomerFavorite, CreatedCustomerFavoriteResponse>();

        CreateMap<UpdateCustomerFavoriteCommand, CustomerFavorite>();
        CreateMap<CustomerFavorite, UpdatedCustomerFavoriteResponse>();

        CreateMap<DeleteCustomerFavoriteCommand, CustomerFavorite>();
        CreateMap<CustomerFavorite, DeletedCustomerFavoriteResponse>();

        CreateMap<CustomerFavorite, GetByIdCustomerFavoriteResponse>();

        CreateMap<CustomerFavorite, GetListCustomerFavoriteListItemDto>();
        CreateMap<IPaginate<CustomerFavorite>, GetListResponse<GetListCustomerFavoriteListItemDto>>();

        CreateMap<CustomerFavorite, GetByCustomerIdCustomerFavoriteListItemDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Advert.Car.ModalExtension.CarModel.Brand.Name))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Advert.Car.ModalExtension.CarModel.ModelName))
                .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.Advert.Car.ModalExtension.ModelYear))
                .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.Advert.Car.ModalExtension.ModelYear))
                .ForMember(dest => dest.Kilometers, opt => opt.MapFrom(src => src.Advert.Car.Kilometers))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Advert.Car.Price))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.Advert.CreatedDate));
        CreateMap<IPaginate<CustomerFavorite>, GetListResponse<GetByCustomerIdCustomerFavoriteListItemDto>>();
    }
}