using Application.Features.Cars.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Cars.Constants.CarsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarQuery : IRequest<GetListResponse<GetListCarListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, GetListResponse<GetListCarListItemDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarListItemDto>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Car> cars = await _carRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: i => i
                 .Include(i => i.ModalExtension).Include(modelExtension => modelExtension.ModalExtension.CarModel)
                    .Include(i => i.ModalExtension).ThenInclude(modal => modal.Generation)
                    .Include(i => i.ModalExtension).ThenInclude(modal => modal.CarModel).ThenInclude(modal => modal.Brand)
                    .Include(i => i.Seller).ThenInclude(modal => modal.Location)
                    .Include(i => i.Seller).ThenInclude(modal => modal.Licence)
                    .Include(i => i.ExpertizeResult).ThenInclude(modal => modal.ChassisPart)
                    .Include(i => i.ExpertizeResult).ThenInclude(modal => modal.BodyShellPart)
                    .Include(i => i.Color),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCarListItemDto> response = _mapper.Map<GetListResponse<GetListCarListItemDto>>(cars);
            return response;
        }
    }
}