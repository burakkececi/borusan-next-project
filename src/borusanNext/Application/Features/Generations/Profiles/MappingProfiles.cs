using Application.Features.Generations.Commands.Create;
using Application.Features.Generations.Commands.Delete;
using Application.Features.Generations.Commands.Update;
using Application.Features.Generations.Queries.GetById;
using Application.Features.Generations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Generations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateGenerationCommand, Generation>();
        CreateMap<Generation, CreatedGenerationResponse>();

        CreateMap<UpdateGenerationCommand, Generation>();
        CreateMap<Generation, UpdatedGenerationResponse>();

        CreateMap<DeleteGenerationCommand, Generation>();
        CreateMap<Generation, DeletedGenerationResponse>();

        CreateMap<Generation, GetByIdGenerationResponse>();

        CreateMap<Generation, GetListGenerationListItemDto>();
        CreateMap<IPaginate<Generation>, GetListResponse<GetListGenerationListItemDto>>();
    }
}