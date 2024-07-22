using Application.Features.FuelTypes.Constants;
using Application.Features.FuelTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelTypes.Constants.FuelTypesOperationClaims;

namespace Application.Features.FuelTypes.Commands.Update;

public class UpdateFuelTypeCommand : IRequest<UpdatedFuelTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, FuelTypesOperationClaims.Update];

    public class UpdateFuelTypeCommandHandler : IRequestHandler<UpdateFuelTypeCommand, UpdatedFuelTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly FuelTypeBusinessRules _fuelTypeBusinessRules;

        public UpdateFuelTypeCommandHandler(IMapper mapper, IFuelTypeRepository fuelTypeRepository,
                                         FuelTypeBusinessRules fuelTypeBusinessRules)
        {
            _mapper = mapper;
            _fuelTypeRepository = fuelTypeRepository;
            _fuelTypeBusinessRules = fuelTypeBusinessRules;
        }

        public async Task<UpdatedFuelTypeResponse> Handle(UpdateFuelTypeCommand request, CancellationToken cancellationToken)
        {
            FuelType? fuelType = await _fuelTypeRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelTypeBusinessRules.FuelTypeShouldExistWhenSelected(fuelType);
            fuelType = _mapper.Map(request, fuelType);

            await _fuelTypeRepository.UpdateAsync(fuelType!);

            UpdatedFuelTypeResponse response = _mapper.Map<UpdatedFuelTypeResponse>(fuelType);
            return response;
        }
    }
}