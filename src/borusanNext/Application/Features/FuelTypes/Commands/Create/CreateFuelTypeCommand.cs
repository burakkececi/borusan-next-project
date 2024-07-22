using Application.Features.FuelTypes.Constants;
using Application.Features.FuelTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelTypes.Constants.FuelTypesOperationClaims;

namespace Application.Features.FuelTypes.Commands.Create;

public class CreateFuelTypeCommand : IRequest<CreatedFuelTypeResponse>, ISecuredRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, FuelTypesOperationClaims.Create];

    public class CreateFuelTypeCommandHandler : IRequestHandler<CreateFuelTypeCommand, CreatedFuelTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly FuelTypeBusinessRules _fuelTypeBusinessRules;

        public CreateFuelTypeCommandHandler(IMapper mapper, IFuelTypeRepository fuelTypeRepository,
                                         FuelTypeBusinessRules fuelTypeBusinessRules)
        {
            _mapper = mapper;
            _fuelTypeRepository = fuelTypeRepository;
            _fuelTypeBusinessRules = fuelTypeBusinessRules;
        }

        public async Task<CreatedFuelTypeResponse> Handle(CreateFuelTypeCommand request, CancellationToken cancellationToken)
        {
            FuelType fuelType = _mapper.Map<FuelType>(request);

            await _fuelTypeRepository.AddAsync(fuelType);

            CreatedFuelTypeResponse response = _mapper.Map<CreatedFuelTypeResponse>(fuelType);
            return response;
        }
    }
}