using Application.Features.Licences.Commands.Create;
using Application.Features.Licences.Commands.Delete;
using Application.Features.Licences.Commands.Update;
using Application.Features.Licences.Queries.GetById;
using Application.Features.Licences.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Licences.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLicenceCommand, Licence>();
        CreateMap<Licence, CreatedLicenceResponse>();

        CreateMap<UpdateLicenceCommand, Licence>();
        CreateMap<Licence, UpdatedLicenceResponse>();

        CreateMap<DeleteLicenceCommand, Licence>();
        CreateMap<Licence, DeletedLicenceResponse>();

        CreateMap<Licence, GetByIdLicenceResponse>();

        CreateMap<Licence, GetListLicenceListItemDto>();
        CreateMap<IPaginate<Licence>, GetListResponse<GetListLicenceListItemDto>>();
    }
}