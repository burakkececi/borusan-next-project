using Application.Features.BodyTypes.Commands.Create;
using Application.Features.BodyTypes.Commands.Delete;
using Application.Features.BodyTypes.Commands.Update;
using Application.Features.BodyTypes.Queries.GetById;
using Application.Features.BodyTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.BodyTypes.Queries.GetDynamic;

namespace Application.Features.BodyTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBodyTypeCommand, BodyType>();
        CreateMap<BodyType, CreatedBodyTypeResponse>();

        CreateMap<UpdateBodyTypeCommand, BodyType>();
        CreateMap<BodyType, UpdatedBodyTypeResponse>();

        CreateMap<DeleteBodyTypeCommand, BodyType>();
        CreateMap<BodyType, DeletedBodyTypeResponse>();

        CreateMap<BodyType, GetByIdBodyTypeResponse>();

        CreateMap<BodyType, GetListBodyTypeListItemDto>();
        CreateMap<IPaginate<BodyType>, GetListResponse<GetListBodyTypeListItemDto>>();
        CreateMap<BodyType, GetDynamicBodyTypesResponse>();
        CreateMap<IPaginate<BodyType>, GetListResponse<GetDynamicBodyTypesResponse>>();
    }
}