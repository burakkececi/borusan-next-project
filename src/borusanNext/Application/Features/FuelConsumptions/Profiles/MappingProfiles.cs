using Application.Features.FuelConsumptions.Commands.Create;
using Application.Features.FuelConsumptions.Commands.Delete;
using Application.Features.FuelConsumptions.Commands.Update;
using Application.Features.FuelConsumptions.Queries.GetById;
using Application.Features.FuelConsumptions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FuelConsumptions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateFuelConsumptionCommand, FuelConsumption>();
        CreateMap<FuelConsumption, CreatedFuelConsumptionResponse>();

        CreateMap<UpdateFuelConsumptionCommand, FuelConsumption>();
        CreateMap<FuelConsumption, UpdatedFuelConsumptionResponse>();

        CreateMap<DeleteFuelConsumptionCommand, FuelConsumption>();
        CreateMap<FuelConsumption, DeletedFuelConsumptionResponse>();

        CreateMap<FuelConsumption, GetByIdFuelConsumptionResponse>();

        CreateMap<FuelConsumption, GetListFuelConsumptionListItemDto>();
        CreateMap<IPaginate<FuelConsumption>, GetListResponse<GetListFuelConsumptionListItemDto>>();
    }
}