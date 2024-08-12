using Application.Models;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AdvertDetails.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IPaginate<AdvertDetailsReadModel>, GetListResponse<AdvertDetailsReadModel>>();
    }
}
