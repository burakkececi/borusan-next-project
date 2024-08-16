using Application.Features.Brands.Queries.GetDynamic;
using Application.Features.Cars.Queries.GetDynamic;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Models.Queries.GetDynamic;

public class GetDynamicCarQuery : IRequest<GetListResponse<GetDynamicCarResponse>>
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicCarQueryHandler : IRequestHandler<GetDynamicCarQuery, GetListResponse<GetDynamicCarResponse>>
    {
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;
        private readonly ICarRepository _carRepository;

        public GetDynamicCarQueryHandler(IMapper mapper, CarBusinessRules carBusinessRules, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
            _carRepository = carRepository;
        }

        public async Task<GetListResponse<GetDynamicCarResponse>> Handle(GetDynamicCarQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Car> models = await _carRepository.GetListByDynamicAsync(
             dynamic: request.DynamicQuery,
             index: request.PageRequest.PageIndex,
             size: request.PageRequest.PageSize,
             include: i => i
                 .Include(i => i.ModalExtension).Include(modelExtension => modelExtension.ModalExtension.CarModel)
                    .Include(i => i.ModalExtension).ThenInclude(modal=>modal.Generation)
                    .Include(i => i.ModalExtension).ThenInclude(modal=>modal.CarModel).ThenInclude(modal => modal.Brand)
                    .Include(i => i.Engine).ThenInclude(fuel => fuel.FuelType)
                    .Include(i => i.BodyType)
                    .Include(i => i.Transmission)
                    .Include(i => i.Seller)
                    .Include(i => i.ExpertizeResult)
                    .Include(i => i.Color),
             cancellationToken: cancellationToken);

            GetListResponse<GetDynamicCarResponse> response = _mapper.Map<GetListResponse<GetDynamicCarResponse>>(models);
            return response;
        }
    }
}
