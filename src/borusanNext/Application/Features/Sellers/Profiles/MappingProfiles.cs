using Application.Features.Sellers.Commands.Create;
using Application.Features.Sellers.Commands.Delete;
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Queries.GetById;
using Application.Features.Sellers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Sellers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSellerCommand, Seller>();
        CreateMap<Seller, CreatedSellerResponse>();

        CreateMap<UpdateSellerCommand, Seller>();
        CreateMap<Seller, UpdatedSellerResponse>();

        CreateMap<DeleteSellerCommand, Seller>();
        CreateMap<Seller, DeletedSellerResponse>();

        CreateMap<Seller, GetByIdSellerResponse>();

        CreateMap<Seller, GetListSellerListItemDto>();
        CreateMap<IPaginate<Seller>, GetListResponse<GetListSellerListItemDto>>();
    }
}