using Application.Features.CarModels.Constants;
using Application.Features.CarModels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarModels.Constants.CarModelsOperationClaims;

namespace Application.Features.CarModels.Commands.Update;

public class UpdateCarModelCommand : IRequest<UpdatedCarModelResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string ModelName { get; set; }
    public required Guid BrandId { get; set; }

    public string[] Roles => [Admin, Write, CarModelsOperationClaims.Update];

    public class UpdateCarModelCommandHandler : IRequestHandler<UpdateCarModelCommand, UpdatedCarModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;
        private readonly CarModelBusinessRules _carModelBusinessRules;

        public UpdateCarModelCommandHandler(IMapper mapper, ICarModelRepository carModelRepository,
                                         CarModelBusinessRules carModelBusinessRules)
        {
            _mapper = mapper;
            _carModelRepository = carModelRepository;
            _carModelBusinessRules = carModelBusinessRules;
        }

        public async Task<UpdatedCarModelResponse> Handle(UpdateCarModelCommand request, CancellationToken cancellationToken)
        {
            CarModel? carModel = await _carModelRepository.GetAsync(predicate: cm => cm.Id == request.Id, cancellationToken: cancellationToken);
            
            await _carModelBusinessRules.CarModelShouldExistWhenSelected(carModel);
            await _carModelBusinessRules.BrandIdShouldExistWhenSelected(request.BrandId, cancellationToken);

            carModel = _mapper.Map(request, carModel);

            await _carModelRepository.UpdateAsync(carModel!);

            UpdatedCarModelResponse response = _mapper.Map<UpdatedCarModelResponse>(carModel);
            return response;
        }
    }
}