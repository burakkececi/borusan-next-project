using Application.Features.CarColors.Constants;
using Application.Features.CarColors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarColors.Constants.CarColorsOperationClaims;

namespace Application.Features.CarColors.Commands.Create;

public class CreateCarColorCommand : IRequest<CreatedCarColorResponse>, ISecuredRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, CarColorsOperationClaims.Create];

    public class CreateCarColorCommandHandler : IRequestHandler<CreateCarColorCommand, CreatedCarColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarColorRepository _carColorRepository;
        private readonly CarColorBusinessRules _carColorBusinessRules;

        public CreateCarColorCommandHandler(IMapper mapper, ICarColorRepository carColorRepository,
                                         CarColorBusinessRules carColorBusinessRules)
        {
            _mapper = mapper;
            _carColorRepository = carColorRepository;
            _carColorBusinessRules = carColorBusinessRules;
        }

        public async Task<CreatedCarColorResponse> Handle(CreateCarColorCommand request, CancellationToken cancellationToken)
        {
            CarColor carColor = _mapper.Map<CarColor>(request);

            await _carColorRepository.AddAsync(carColor);

            CreatedCarColorResponse response = _mapper.Map<CreatedCarColorResponse>(carColor);
            return response;
        }
    }
}