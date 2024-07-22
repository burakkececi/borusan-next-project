using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cars.Constants.CustomersOperationClaims;

namespace Application.Features.Cars.Commands.Create;

public class CreateCustomerCommand : IRequest<CreatedCustomerResponse>, ISecuredRequest
{
    public required string ChassisNumber { get; set; }
    public required string Plate { get; set; }
    public required int Kilometers { get; set; }
    public required bool SpareKey { get; set; }
    public required DateTime Inquiry { get; set; }
    public required string WheelType { get; set; }
    public required bool SpareWheel { get; set; }
    public required decimal Price { get; set; }
    public required int CarModelId { get; set; }
    public required Guid ColorId { get; set; }
    public required Guid EngineId { get; set; }
    public required Guid BodyTypeId { get; set; }
    public required Guid TransmissionId { get; set; }
    public required Guid TramerId { get; set; }
    public required Guid AdvertId { get; set; }
    public required Guid SellerId { get; set; }

    public string[] Roles => [Admin, Write, CustomersOperationClaims.Create];

    public class CreateCarCommandHandler : IRequestHandler<CreateCustomerCommand, CreatedCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CustomerBusinessRules _carBusinessRules;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository,
                                         CustomerBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<CreatedCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);

            await _carRepository.AddAsync(car);

            CreatedCustomerResponse response = _mapper.Map<CreatedCustomerResponse>(car);
            return response;
        }
    }
}