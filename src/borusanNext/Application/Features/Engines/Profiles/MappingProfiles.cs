using Application.Features.Engines.Commands.Create;
using Application.Features.Engines.Commands.Delete;
using Application.Features.Engines.Commands.Update;
using Application.Features.Engines.Queries.GetById;
using Application.Features.Engines.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Engines.Queries.GetDynamic;

namespace Application.Features.Engines.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateEngineCommand, Engine>();
        CreateMap<Engine, CreatedEngineResponse>();

        CreateMap<UpdateEngineCommand, Engine>();
        CreateMap<Engine, UpdatedEngineResponse>();

        CreateMap<DeleteEngineCommand, Engine>();
        CreateMap<Engine, DeletedEngineResponse>();

        CreateMap<Engine, GetByIdEngineResponse>();

        CreateMap<Engine, GetListEngineListItemDto>();
        CreateMap<IPaginate<Engine>, GetListResponse<GetListEngineListItemDto>>();

        CreateMap<Engine, GetDynamicEngineResponse>().ReverseMap();
        CreateMap<IPaginate<Engine>, GetListResponse<GetDynamicEngineResponse>>().ReverseMap();
    }
}