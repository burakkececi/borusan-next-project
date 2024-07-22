using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cars.Constants.CarsOperationClaims;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommand : IRequest<UpdatedCarResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
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
    public required Guid AdvertId { get; set; }
    public required Guid SellerId { get; set; }

    public string[] Roles => [Admin, Write, CarsOperationClaims.Update];

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public UpdateCarCommandHandler(IMapper mapper, ICarRepository carRepository,
                                         CarBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<UpdatedCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _carBusinessRules.CarShouldExistWhenSelected(car);
            car = _mapper.Map(request, car);

            await _carRepository.UpdateAsync(car!);

            UpdatedCarResponse response = _mapper.Map<UpdatedCarResponse>(car);
            return response;
        }
    }
}