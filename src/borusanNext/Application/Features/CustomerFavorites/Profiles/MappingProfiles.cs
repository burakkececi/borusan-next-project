using Application.Features.CustomerFavorites.Commands.Create;
using Application.Features.CustomerFavorites.Commands.Delete;
using Application.Features.CustomerFavorites.Commands.Update;
using Application.Features.CustomerFavorites.Queries.GetById;
using Application.Features.CustomerFavorites.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CustomerFavorites.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomerFavoriteCommand, CustomerFavorite>();
        CreateMap<CustomerFavorite, CreatedCustomerFavoriteResponse>();

        CreateMap<UpdateCustomerFavoriteCommand, CustomerFavorite>();
        CreateMap<CustomerFavorite, UpdatedCustomerFavoriteResponse>();

        CreateMap<DeleteCustomerFavoriteCommand, CustomerFavorite>();
        CreateMap<CustomerFavorite, DeletedCustomerFavoriteResponse>();

        CreateMap<CustomerFavorite, GetByIdCustomerFavoriteResponse>();

        CreateMap<CustomerFavorite, GetListCustomerFavoriteListItemDto>();
        CreateMap<IPaginate<CustomerFavorite>, GetListResponse<GetListCustomerFavoriteListItemDto>>();
    }
}