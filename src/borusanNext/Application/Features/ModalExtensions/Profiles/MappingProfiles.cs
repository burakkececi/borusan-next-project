using Application.Features.ModalExtensions.Commands.Create;
using Application.Features.ModalExtensions.Commands.Delete;
using Application.Features.ModalExtensions.Commands.Update;
using Application.Features.ModalExtensions.Queries.GetById;
using Application.Features.ModalExtensions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.ModalExtensions.Queries.GetDynamic;

namespace Application.Features.ModalExtensions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateModalExtensionCommand, ModalExtension>();
        CreateMap<ModalExtension, CreatedModalExtensionResponse>();

        CreateMap<UpdateModalExtensionCommand, ModalExtension>();
        CreateMap<ModalExtension, UpdatedModalExtensionResponse>();

        CreateMap<DeleteModalExtensionCommand, ModalExtension>();
        CreateMap<ModalExtension, DeletedModalExtensionResponse>();

        CreateMap<ModalExtension, GetByIdModalExtensionResponse>();

        CreateMap<ModalExtension, GetListModalExtensionListItemDto>();
        CreateMap<IPaginate<ModalExtension>, GetListResponse<GetListModalExtensionListItemDto>>();
        CreateMap<ModalExtension, GetDynamicModalExtensionsResponse>();
        CreateMap<IPaginate<ModalExtension>, GetListResponse<GetDynamicModalExtensionsResponse>>();
    }
}