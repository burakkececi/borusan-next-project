using Application.Features.ExpertizeResults.Commands.Create;
using Application.Features.ExpertizeResults.Commands.Delete;
using Application.Features.ExpertizeResults.Commands.Update;
using Application.Features.ExpertizeResults.Queries.GetById;
using Application.Features.ExpertizeResults.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ExpertizeResults.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateExpertizeResultCommand, ExpertizeResult>();
        CreateMap<ExpertizeResult, CreatedExpertizeResultResponse>();

        CreateMap<UpdateExpertizeResultCommand, ExpertizeResult>();
        CreateMap<ExpertizeResult, UpdatedExpertizeResultResponse>();

        CreateMap<DeleteExpertizeResultCommand, ExpertizeResult>();
        CreateMap<ExpertizeResult, DeletedExpertizeResultResponse>();

        CreateMap<ExpertizeResult, GetByIdExpertizeResultResponse>();

        CreateMap<ExpertizeResult, GetListExpertizeResultListItemDto>();
        CreateMap<IPaginate<ExpertizeResult>, GetListResponse<GetListExpertizeResultListItemDto>>();
    }
}