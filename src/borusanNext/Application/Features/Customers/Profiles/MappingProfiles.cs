using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Queries.GetById;
using Application.Features.Customers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Customers.Queries.GetDynamic;
using Application.Features.Customers.Queries.GetByUserId;

namespace Application.Features.Customers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<Customer, CreatedCustomerResponse>();

        CreateMap<UpdateCustomerCommand, Customer>();
        CreateMap<Customer, UpdatedCustomerResponse>();

        CreateMap<DeleteCustomerCommand, Customer>();
        CreateMap<Customer, DeletedCustomerResponse>();

        CreateMap<Customer, GetByIdCustomerResponse>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));

        CreateMap<Customer, GetByUserIdCustomerResponse>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));

        CreateMap<Customer, GetListCustomerListItemDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));
        CreateMap<IPaginate<Customer>, GetListResponse<GetListCustomerListItemDto>>();

        CreateMap<Customer, GetDynamicCustomerResponse>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Address.District));
        CreateMap<IPaginate<Customer>, GetListResponse<GetDynamicCustomerResponse>>();
    }
}