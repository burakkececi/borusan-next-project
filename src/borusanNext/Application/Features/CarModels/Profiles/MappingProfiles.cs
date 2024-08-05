using Application.Features.CarModels.Commands.Create;
using Application.Features.CarModels.Commands.Delete;
using Application.Features.CarModels.Commands.Update;
using Application.Features.CarModels.Queries.GetById;
using Application.Features.CarModels.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.CarModels.Queries.GetDynamic;

namespace Application.Features.CarModels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCarModelCommand, CarModel>();
        CreateMap<CarModel, CreatedCarModelResponse>();

        CreateMap<UpdateCarModelCommand, CarModel>();
        CreateMap<CarModel, UpdatedCarModelResponse>();

        CreateMap<DeleteCarModelCommand, CarModel>();
        CreateMap<CarModel, DeletedCarModelResponse>();

        CreateMap<CarModel, GetByIdCarModelResponse>();

        CreateMap<CarModel, GetListCarModelListItemDto>();
        CreateMap<IPaginate<CarModel>, GetListResponse<GetListCarModelListItemDto>>();
        CreateMap<CarModel, GetDynamicCarModelsResponse>();
        CreateMap<IPaginate<CarModel>, GetListResponse<GetDynamicCarModelsResponse>>();
    }
}