using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomerCommand, Car>();
        CreateMap<Car, CreatedCustomerResponse>();

        CreateMap<UpdateCustomerCommand, Car>();
        CreateMap<Car, UpdatedCustomerResponse>();

        CreateMap<DeleteCustomerCommand, Car>();
        CreateMap<Car, DeletedCustomerResponse>();

        CreateMap<Car, GetByIdCarResponse>();

        CreateMap<Car, GetListCustomerListItemDto>();
        CreateMap<IPaginate<Car>, GetListResponse<GetListCustomerListItemDto>>();
    }
}