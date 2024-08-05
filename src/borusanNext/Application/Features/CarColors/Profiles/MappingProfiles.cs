using Application.Features.CarColors.Commands.Create;
using Application.Features.CarColors.Commands.Delete;
using Application.Features.CarColors.Commands.Update;
using Application.Features.CarColors.Queries.GetById;
using Application.Features.CarColors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.CarColors.Queries.GetDynamic;

namespace Application.Features.CarColors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCarColorCommand, CarColor>();
        CreateMap<CarColor, CreatedCarColorResponse>();

        CreateMap<UpdateCarColorCommand, CarColor>();
        CreateMap<CarColor, UpdatedCarColorResponse>();

        CreateMap<DeleteCarColorCommand, CarColor>();
        CreateMap<CarColor, DeletedCarColorResponse>();

        CreateMap<CarColor, GetByIdCarColorResponse>();

        CreateMap<CarColor, GetListCarColorListItemDto>();
        CreateMap<IPaginate<CarColor>, GetListResponse<GetListCarColorListItemDto>>();
        CreateMap<CarColor, GetDynamicColorResponse>();
        CreateMap<IPaginate<CarColor>, GetListResponse<GetDynamicColorResponse>>();
    }
}