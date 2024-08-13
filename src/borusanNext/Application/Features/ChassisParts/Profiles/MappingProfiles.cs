using Application.Features.ChassisParts.Commands.Create;
using Application.Features.ChassisParts.Commands.Delete;
using Application.Features.ChassisParts.Commands.Update;
using Application.Features.ChassisParts.Queries.GetById;
using Application.Features.ChassisParts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Engines.Queries.GetDynamic;
using Application.Features.ChassisParts.Queries.GetDynamic;

namespace Application.Features.ChassisParts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateChassisPartCommand, ChassisPart>();
        CreateMap<ChassisPart, CreatedChassisPartResponse>();

        CreateMap<UpdateChassisPartCommand, ChassisPart>();
        CreateMap<ChassisPart, UpdatedChassisPartResponse>();

        CreateMap<DeleteChassisPartCommand, ChassisPart>();
        CreateMap<ChassisPart, DeletedChassisPartResponse>();

        CreateMap<ChassisPart, GetByIdChassisPartResponse>();

        CreateMap<ChassisPart, GetListChassisPartListItemDto>();
        CreateMap<IPaginate<ChassisPart>, GetListResponse<GetListChassisPartListItemDto>>();

        CreateMap<ChassisPart, GetDynamicChassisPartsResponse>().ReverseMap();
        CreateMap<IPaginate<ChassisPart>, GetListResponse<GetDynamicChassisPartsResponse>>().ReverseMap();
    }
}