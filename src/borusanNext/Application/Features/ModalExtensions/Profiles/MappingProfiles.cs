using Application.Features.ModalExtensions.Commands.Create;
using Application.Features.ModalExtensions.Commands.Delete;
using Application.Features.ModalExtensions.Commands.Update;
using Application.Features.ModalExtensions.Queries.GetById;
using Application.Features.ModalExtensions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.ModalExtensions.Queries.GetDynamic;

namespace Application.Features.ModalExtensions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateModalExtensionCommand, ModalExtension>();
        CreateMap<ModalExtension, CreatedModalExtensionResponse>();

        CreateMap<UpdateModalExtensionCommand, ModalExtension>();
        CreateMap<ModalExtension, UpdatedModalExtensionResponse>();

        CreateMap<DeleteModalExtensionCommand, ModalExtension>();
        CreateMap<ModalExtension, DeletedModalExtensionResponse>();

        CreateMap<ModalExtension, GetByIdModalExtensionResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Lenght, opt => opt.MapFrom(src => src.Lenght))
            .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.FuelTank, opt => opt.MapFrom(src => src.FuelTank))
            .ForMember(dest => dest.LuggageCapacity, opt => opt.MapFrom(src => src.LuggageCapacity))
            .ForMember(dest => dest.EmptyWeight, opt => opt.MapFrom(src => src.EmptyWeight))
            .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.ModelYear))
            .ForMember(dest => dest.CarModelId, opt => opt.MapFrom(src => src.CarModel.Id))
            .ForMember(dest => dest.CarModelName, opt => opt.MapFrom(src => src.CarModel.ModelName))
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.CarModel.Brand.Id))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.CarModel.Brand.Name))
            .ForMember(dest => dest.BrandLogo, opt => opt.MapFrom(src => src.CarModel.Brand.Logo))
            .ForMember(dest => dest.GenerationId, opt => opt.MapFrom(src => src.Generation.Id))
            .ForMember(dest => dest.GenerationName, opt => opt.MapFrom(src => src.Generation.Name));

        CreateMap<ModalExtension, GetListModalExtensionListItemDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Lenght, opt => opt.MapFrom(src => src.Lenght))
            .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.FuelTank, opt => opt.MapFrom(src => src.FuelTank))
            .ForMember(dest => dest.LuggageCapacity, opt => opt.MapFrom(src => src.LuggageCapacity))
            .ForMember(dest => dest.EmptyWeight, opt => opt.MapFrom(src => src.EmptyWeight))
            .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.ModelYear))
            .ForMember(dest => dest.CarModelId, opt => opt.MapFrom(src => src.CarModel.Id))
            //.ForMember(dest => dest.CarModelName, opt => opt.MapFrom(src => src.CarModel.ModelName))
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.CarModel.Brand.Id))
            //.ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.CarModel.Brand.Name))
            //.ForMember(dest => dest.BrandLogo, opt => opt.MapFrom(src => src.CarModel.Brand.Logo))
            .ForMember(dest => dest.GenerationId, opt => opt.MapFrom(src => src.Generation.Id));
        //.ForMember(dest => dest.GenerationName, opt => opt.MapFrom(src => src.Generation.Name));
        CreateMap<IPaginate<ModalExtension>, GetListResponse<GetListModalExtensionListItemDto>>();
        CreateMap<ModalExtension, GetDynamicModalExtensionsResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Lenght, opt => opt.MapFrom(src => src.Lenght))
            .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.FuelTank, opt => opt.MapFrom(src => src.FuelTank))
            .ForMember(dest => dest.LuggageCapacity, opt => opt.MapFrom(src => src.LuggageCapacity))
            .ForMember(dest => dest.EmptyWeight, opt => opt.MapFrom(src => src.EmptyWeight))
            .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.ModelYear))
            .ForMember(dest => dest.CarModelId, opt => opt.MapFrom(src => src.CarModel.Id))
            .ForMember(dest => dest.CarModelName, opt => opt.MapFrom(src => src.CarModel.ModelName))
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.CarModel.Brand.Id))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.CarModel.Brand.Name))
            .ForMember(dest => dest.BrandLogo, opt => opt.MapFrom(src => src.CarModel.Brand.Logo))
            .ForMember(dest => dest.GenerationId, opt => opt.MapFrom(src => src.Generation.Id))
            .ForMember(dest => dest.GenerationName, opt => opt.MapFrom(src => src.Generation.Name))
            .ForMember(dest => dest.EngineNo, opt => opt.MapFrom(src => src.Engine.EngineNo))
            .ForMember(dest => dest.EngineCapacity, opt => opt.MapFrom(src => src.Engine.EngineCapacity))
            .ForMember(dest => dest.MotorPower, opt => opt.MapFrom(src => src.Engine.MotorPower))
            .ForMember(dest => dest.MaximumTorque, opt => opt.MapFrom(src => src.Engine.MaximumTorque))
            .ForMember(dest => dest.Acceleration, opt => opt.MapFrom(src => src.Engine.Acceleration))
            .ForMember(dest => dest.MaximumSpeed, opt => opt.MapFrom(src => src.Engine.MaximumSpeed))
            .ForMember(dest => dest.FuelTankVolume, opt => opt.MapFrom(src => src.Engine.FuelTankVolume))
            .ForMember(dest => dest.OutOfTownConsumptionRate, opt => opt.MapFrom(src => src.Engine.AverageConsumptionRate))
            .ForMember(dest => dest.UrbanConsumptionRate, opt => opt.MapFrom(src => src.Engine.UrbanConsumptionRate))
            .ForMember(dest => dest.AverageConsumptionRate, opt => opt.MapFrom(src => src.Engine.AverageConsumptionRate))
            .ForMember(dest => dest.FuelTypeName, opt => opt.MapFrom(src => src.Engine.FuelType.Name))
            .ForMember(dest => dest.BodyTypeName, opt => opt.MapFrom(src => src.BodyType.BodyName))
            .ForMember(dest => dest.BodyTypeDoor, opt => opt.MapFrom(src => src.BodyType.Door))
            .ForMember(dest => dest.TranmissionName, opt => opt.MapFrom(src => src.Transmission.Name))
            ;
        CreateMap<IPaginate<ModalExtension>, GetListResponse<GetDynamicModalExtensionsResponse>>();
    }
}