using Application.Features.Adverts.Commands.Create;
using Application.Features.Adverts.Commands.Delete;
using Application.Features.Adverts.Commands.Update;
using Application.Features.Adverts.Queries.GetById;
using Application.Features.Adverts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Adverts.Queries.GetDynamic;

namespace Application.Features.Adverts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAdvertCommand, Advert>();
        CreateMap<Advert, CreatedAdvertResponse>();

        CreateMap<UpdateAdvertCommand, Advert>();
        CreateMap<Advert, UpdatedAdvertResponse>();

        CreateMap<DeleteAdvertCommand, Advert>();
        CreateMap<Advert, DeletedAdvertResponse>();

        CreateMap<Advert, GetByIdAdvertResponse>();

        CreateMap<Advert, GetListAdvertListItemDto>();
        CreateMap<IPaginate<Advert>, GetListResponse<GetListAdvertListItemDto>>();
        CreateMap<Advert, GetDynamicAdvertResponse>();
        CreateMap<IPaginate<Advert>, GetListResponse<GetDynamicAdvertResponse>>();
    }
}