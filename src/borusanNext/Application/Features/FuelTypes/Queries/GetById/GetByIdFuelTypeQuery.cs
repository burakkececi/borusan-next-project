using Application.Features.FuelTypes.Constants;
using Application.Features.FuelTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelTypes.Constants.FuelTypesOperationClaims;

namespace Application.Features.FuelTypes.Queries.GetById;

public class GetByIdFuelTypeQuery : IRequest<GetByIdFuelTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdFuelTypeQueryHandler : IRequestHandler<GetByIdFuelTypeQuery, GetByIdFuelTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly FuelTypeBusinessRules _fuelTypeBusinessRules;

        public GetByIdFuelTypeQueryHandler(IMapper mapper, IFuelTypeRepository fuelTypeRepository, FuelTypeBusinessRules fuelTypeBusinessRules)
        {
            _mapper = mapper;
            _fuelTypeRepository = fuelTypeRepository;
            _fuelTypeBusinessRules = fuelTypeBusinessRules;
        }

        public async Task<GetByIdFuelTypeResponse> Handle(GetByIdFuelTypeQuery request, CancellationToken cancellationToken)
        {
            FuelType? fuelType = await _fuelTypeRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelTypeBusinessRules.FuelTypeShouldExistWhenSelected(fuelType);

            GetByIdFuelTypeResponse response = _mapper.Map<GetByIdFuelTypeResponse>(fuelType);
            return response;
        }
    }
}