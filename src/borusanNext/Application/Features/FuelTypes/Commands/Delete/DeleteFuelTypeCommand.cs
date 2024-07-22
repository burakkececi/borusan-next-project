using Application.Features.FuelTypes.Constants;
using Application.Features.FuelTypes.Constants;
using Application.Features.FuelTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelTypes.Constants.FuelTypesOperationClaims;

namespace Application.Features.FuelTypes.Commands.Delete;

public class DeleteFuelTypeCommand : IRequest<DeletedFuelTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, FuelTypesOperationClaims.Delete];

    public class DeleteFuelTypeCommandHandler : IRequestHandler<DeleteFuelTypeCommand, DeletedFuelTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly FuelTypeBusinessRules _fuelTypeBusinessRules;

        public DeleteFuelTypeCommandHandler(IMapper mapper, IFuelTypeRepository fuelTypeRepository,
                                         FuelTypeBusinessRules fuelTypeBusinessRules)
        {
            _mapper = mapper;
            _fuelTypeRepository = fuelTypeRepository;
            _fuelTypeBusinessRules = fuelTypeBusinessRules;
        }

        public async Task<DeletedFuelTypeResponse> Handle(DeleteFuelTypeCommand request, CancellationToken cancellationToken)
        {
            FuelType? fuelType = await _fuelTypeRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelTypeBusinessRules.FuelTypeShouldExistWhenSelected(fuelType);

            await _fuelTypeRepository.DeleteAsync(fuelType!);

            DeletedFuelTypeResponse response = _mapper.Map<DeletedFuelTypeResponse>(fuelType);
            return response;
        }
    }
}