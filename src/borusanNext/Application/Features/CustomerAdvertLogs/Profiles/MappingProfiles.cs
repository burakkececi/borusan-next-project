using Application.Features.CustomerAdvertLogs.Commands.Create;
using Application.Features.CustomerAdvertLogs.Commands.Delete;
using Application.Features.CustomerAdvertLogs.Commands.Update;
using Application.Features.CustomerAdvertLogs.Queries.GetById;
using Application.Features.CustomerAdvertLogs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CustomerAdvertLogs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomerAdvertLogCommand, CustomerAdvertLog>();
        CreateMap<CustomerAdvertLog, CreatedCustomerAdvertLogResponse>();

        CreateMap<UpdateCustomerAdvertLogCommand, CustomerAdvertLog>();
        CreateMap<CustomerAdvertLog, UpdatedCustomerAdvertLogResponse>();

        CreateMap<DeleteCustomerAdvertLogCommand, CustomerAdvertLog>();
        CreateMap<CustomerAdvertLog, DeletedCustomerAdvertLogResponse>();

        CreateMap<CustomerAdvertLog, GetByIdCustomerAdvertLogResponse>();

        CreateMap<CustomerAdvertLog, GetListCustomerAdvertLogListItemDto>();
        CreateMap<IPaginate<CustomerAdvertLog>, GetListResponse<GetListCustomerAdvertLogListItemDto>>();
    }
}