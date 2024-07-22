using Application.Features.FuelTypes.Commands.Create;
using Application.Features.FuelTypes.Commands.Delete;
using Application.Features.FuelTypes.Commands.Update;
using Application.Features.FuelTypes.Queries.GetById;
using Application.Features.FuelTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FuelTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateFuelTypeCommand, FuelType>();
        CreateMap<FuelType, CreatedFuelTypeResponse>();

        CreateMap<UpdateFuelTypeCommand, FuelType>();
        CreateMap<FuelType, UpdatedFuelTypeResponse>();

        CreateMap<DeleteFuelTypeCommand, FuelType>();
        CreateMap<FuelType, DeletedFuelTypeResponse>();

        CreateMap<FuelType, GetByIdFuelTypeResponse>();

        CreateMap<FuelType, GetListFuelTypeListItemDto>();
        CreateMap<IPaginate<FuelType>, GetListResponse<GetListFuelTypeListItemDto>>();
    }
}