using Application.Features.CarModels.Constants;
using Application.Features.CarModels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarModels.Constants.CarModelsOperationClaims;

namespace Application.Features.CarModels.Commands.Create;

public class CreateCarModelCommand : IRequest<CreatedCarModelResponse>, ISecuredRequest
{
    public required string ModelName { get; set; }
    public required Guid BrandId { get; set; }

    public string[] Roles => [Admin, Write, CarModelsOperationClaims.Create];

    public class CreateCarModelCommandHandler : IRequestHandler<CreateCarModelCommand, CreatedCarModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;
        private readonly CarModelBusinessRules _carModelBusinessRules;

        public CreateCarModelCommandHandler(IMapper mapper, ICarModelRepository carModelRepository,
                                         CarModelBusinessRules carModelBusinessRules)
        {
            _mapper = mapper;
            _carModelRepository = carModelRepository;
            _carModelBusinessRules = carModelBusinessRules;
        }

        public async Task<CreatedCarModelResponse> Handle(CreateCarModelCommand request, CancellationToken cancellationToken)
        {
            CarModel carModel = _mapper.Map<CarModel>(request);

            await _carModelRepository.AddAsync(carModel);

            CreatedCarModelResponse response = _mapper.Map<CreatedCarModelResponse>(carModel);
            return response;
        }
    }
}