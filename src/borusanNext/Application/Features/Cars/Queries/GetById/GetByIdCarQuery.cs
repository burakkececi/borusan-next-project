using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cars.Constants.CarsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQuery : IRequest<GetByIdCarResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public GetByIdCarQueryHandler(IMapper mapper, ICarRepository carRepository, CarBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<GetByIdCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(predicate: c => c.Id == request.Id, 
                include: i => i
                 .Include(i => i.ModalExtension).Include(modelExtension => modelExtension.ModalExtension.CarModel)
                    .Include(i => i.ModalExtension).ThenInclude(modal => modal.Generation)
                    .Include(i => i.ModalExtension).ThenInclude(modal => modal.CarModel).ThenInclude(modal => modal.Brand)
                    .Include(i => i.Seller).ThenInclude(modal => modal.Address)
                    .Include(i => i.ExpertizeResult).ThenInclude(modal => modal.ChassisPart)
                    .Include(i => i.ExpertizeResult).ThenInclude(modal => modal.BodyShellPart)
                    .Include(i => i.Color),
                cancellationToken: cancellationToken);
            await _carBusinessRules.CarShouldExistWhenSelected(car);

            GetByIdCarResponse response = _mapper.Map<GetByIdCarResponse>(car);
            return response;
        }
    }
}