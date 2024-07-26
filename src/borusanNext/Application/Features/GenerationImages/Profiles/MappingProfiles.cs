using Application.Features.GenerationImages.Commands.Create;
using Application.Features.GenerationImages.Commands.Delete;
using Application.Features.GenerationImages.Commands.Update;
using Application.Features.GenerationImages.Queries.GetById;
using Application.Features.GenerationImages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.GenerationImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateGenerationImageCommand, GenerationImage>();
        CreateMap<GenerationImage, CreatedGenerationImageResponse>();

        CreateMap<UpdateGenerationImageCommand, GenerationImage>();
        CreateMap<GenerationImage, UpdatedGenerationImageResponse>();

        CreateMap<DeleteGenerationImageCommand, GenerationImage>();
        CreateMap<GenerationImage, DeletedGenerationImageResponse>();

        CreateMap<GenerationImage, GetByIdGenerationImageResponse>();

        CreateMap<GenerationImage, GetListGenerationImageListItemDto>();
        CreateMap<IPaginate<GenerationImage>, GetListResponse<GetListGenerationImageListItemDto>>();
    }
}