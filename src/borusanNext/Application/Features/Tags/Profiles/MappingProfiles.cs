using Application.Features.Tags.Commands.Create;
using Application.Features.Tags.Commands.Delete;
using Application.Features.Tags.Commands.Update;
using Application.Features.Tags.Queries.GetById;
using Application.Features.Tags.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Tags.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTagCommand, Tag>();
        CreateMap<Tag, CreatedTagResponse>();

        CreateMap<UpdateTagCommand, Tag>();
        CreateMap<Tag, UpdatedTagResponse>();

        CreateMap<DeleteTagCommand, Tag>();
        CreateMap<Tag, DeletedTagResponse>();

        CreateMap<Tag, GetByIdTagResponse>();

        CreateMap<Tag, GetListTagListItemDto>();
        CreateMap<IPaginate<Tag>, GetListResponse<GetListTagListItemDto>>();
    }
}