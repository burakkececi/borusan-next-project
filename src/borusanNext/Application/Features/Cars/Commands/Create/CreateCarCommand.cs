using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cars.Constants.CarsOperationClaims;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand : IRequest<CreatedCarResponse>, ISecuredRequest
{
    public required string ChassisNumber { get; set; }
    public required string Plate { get; set; }
    public required int Kilometers { get; set; }
    public required bool SpareKey { get; set; }
    public required DateTime Inquiry { get; set; }
    public required string WheelType { get; set; }
    public required bool SpareWheel { get; set; }
    public required decimal Price { get; set; }
    public required Guid CarModelId { get; set; }
    public required Guid ColorId { get; set; }
    public required Guid EngineId { get; set; }
    public required Guid BodyTypeId { get; set; }
    public required Guid TransmissionId { get; set; }
    public required Guid TramerId { get; set; }
    public required Guid SellerId { get; set; }

    public string[] Roles => [Admin, Write, CarsOperationClaims.Create];

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository,
                                         CarBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);

            await _carBusinessRules.CarModelIdShouldExistWhenSelected(request.CarModelId, cancellationToken);
            await _carBusinessRules.CarColorIdShouldExistWhenSelected(request.ColorId, cancellationToken);
            await _carBusinessRules.EngineIdShouldExistWhenSelected(request.EngineId, cancellationToken);
            await _carBusinessRules.BodyTypeIdShouldExistWhenSelected(request.BodyTypeId, cancellationToken);
            await _carBusinessRules.TransmissionIdShouldExistWhenSelected(request.TransmissionId, cancellationToken);
            await _carBusinessRules.ExpertizeResultIdShouldExistWhenSelected(request.TramerId, cancellationToken);
            await _carBusinessRules.SellerIdShouldExistWhenSelected(request.SellerId, cancellationToken);

            await _carRepository.AddAsync(car);

            CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(car);
            return response;
        }
    }
}