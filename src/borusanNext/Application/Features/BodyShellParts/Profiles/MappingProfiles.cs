using Application.Features.BodyShellParts.Commands.Create;
using Application.Features.BodyShellParts.Commands.Delete;
using Application.Features.BodyShellParts.Commands.Update;
using Application.Features.BodyShellParts.Queries.GetById;
using Application.Features.BodyShellParts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.BodyShellParts.Queries.GetDynamic;

namespace Application.Features.BodyShellParts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBodyShellPartCommand, BodyShellPart>();
        CreateMap<BodyShellPart, CreatedBodyShellPartResponse>();

        CreateMap<UpdateBodyShellPartCommand, BodyShellPart>();
        CreateMap<BodyShellPart, UpdatedBodyShellPartResponse>();

        CreateMap<DeleteBodyShellPartCommand, BodyShellPart>();
        CreateMap<BodyShellPart, DeletedBodyShellPartResponse>();

        CreateMap<BodyShellPart, GetByIdBodyShellPartResponse>();

        CreateMap<BodyShellPart, GetListBodyShellPartListItemDto>();
        CreateMap<IPaginate<BodyShellPart>, GetListResponse<GetListBodyShellPartListItemDto>>();
        CreateMap<BodyShellPart, GetDynamicBodyShellPartsResponse>();
        CreateMap<IPaginate<BodyShellPart>, GetListResponse<GetDynamicBodyShellPartsResponse>>();
    }
}