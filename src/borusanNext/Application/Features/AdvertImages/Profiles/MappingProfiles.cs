using Application.Features.AdvertImages.Commands.Create;
using Application.Features.AdvertImages.Commands.Delete;
using Application.Features.AdvertImages.Commands.Update;
using Application.Features.AdvertImages.Queries.GetById;
using Application.Features.AdvertImages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AdvertImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAdvertImageCommand, AdvertImage>();
        CreateMap<AdvertImage, CreatedAdvertImageResponse>();

        CreateMap<UpdateAdvertImageCommand, AdvertImage>();
        CreateMap<AdvertImage, UpdatedAdvertImageResponse>();

        CreateMap<DeleteAdvertImageCommand, AdvertImage>();
        CreateMap<AdvertImage, DeletedAdvertImageResponse>();

        CreateMap<AdvertImage, GetByIdAdvertImageResponse>();

        CreateMap<AdvertImage, GetListAdvertImageListItemDto>();
        CreateMap<IPaginate<AdvertImage>, GetListResponse<GetListAdvertImageListItemDto>>();
    }
}