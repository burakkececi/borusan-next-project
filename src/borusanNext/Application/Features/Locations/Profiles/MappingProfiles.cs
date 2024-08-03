using Application.Features.Locations.Commands.Create;
using Application.Features.Locations.Commands.Delete;
using Application.Features.Locations.Commands.Update;
using Application.Features.Locations.Queries.GetById;
using Application.Features.Locations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Locations.Queries.GetDynamic;

namespace Application.Features.Locations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLocationCommand, Location>();
        CreateMap<Location, CreatedLocationResponse>();

        CreateMap<UpdateLocationCommand, Location>();
        CreateMap<Location, UpdatedLocationResponse>();

        CreateMap<DeleteLocationCommand, Location>();
        CreateMap<Location, DeletedLocationResponse>();

        CreateMap<Location, GetByIdLocationResponse>();

        CreateMap<Location, GetListLocationListItemDto>();
        CreateMap<IPaginate<Location>, GetListResponse<GetListLocationListItemDto>>();
        CreateMap<Location, GetDynamicLocaitonResponse>();
        CreateMap<IPaginate<Location>, GetListResponse<GetDynamicLocaitonResponse>>();
    }
}