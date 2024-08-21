using Application.Models;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CarModelDetails.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IPaginate<CarModelDetailsReadModel>, GetListResponse<CarModelDetailsReadModel>>().ReverseMap();
    }
}
