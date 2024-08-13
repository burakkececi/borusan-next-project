using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.CarModels.Queries.GetDynamic;
using Application.Features.Cars.Queries.GetDynamic;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCarCommand, Car>();
        CreateMap<Car, CreatedCarResponse>();

        CreateMap<UpdateCarCommand, Car>();
        CreateMap<Car, UpdatedCarResponse>();

        CreateMap<DeleteCarCommand, Car>();
        CreateMap<Car, DeletedCarResponse>();

        CreateMap<Car, GetByIdCarResponse>();

        CreateMap<Car, GetListCarListItemDto>();
        CreateMap<IPaginate<Car>, GetListResponse<GetListCarListItemDto>>();

        CreateMap<Car, GetDynamicCarResponse>()
        .ForMember(dest => dest.SellerName, opt => opt.MapFrom(src => src.Seller.Name))
        .ForMember(dest => dest.CarModelName, opt => opt.MapFrom(src => src.ModalExtension.CarModel.ModelName))
        .ForMember(dest => dest.CarModelId, opt => opt.MapFrom(src => src.ModalExtension.CarModelId))
        .ForMember(dest => dest.ModelExtensionName, opt => opt.MapFrom(src => src.ModalExtension.Name))
        .ForMember(dest => dest.GenerationName, opt => opt.MapFrom(src => src.ModalExtension.Generation.Name))
        .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.ModalExtension.CarModel.Brand.Name))
        .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
        .ForMember(dest => dest.SellerName, opt => opt.MapFrom(src => src.Seller.Name));

        CreateMap<IPaginate<Car>, GetListResponse<GetDynamicCarResponse>>();
    }
}