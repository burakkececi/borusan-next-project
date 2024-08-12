using Application.Models;
using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Adverts.Queries.GetList;

public class GetListAdvertListItemDto : IDto
{
    public Guid Id { get; set; }
    public int AdvertNo { get; set; }
    public AdvertDetailsReadModel AdvertDetailsReadModel { get; set; }
}