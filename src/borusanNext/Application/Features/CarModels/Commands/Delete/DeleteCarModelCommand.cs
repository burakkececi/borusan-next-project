using Application.Features.CarModels.Constants;
using Application.Features.CarModels.Constants;
using Application.Features.CarModels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarModels.Constants.CarModelsOperationClaims;

namespace Application.Features.CarModels.Commands.Delete;

public class DeleteCarModelCommand : IRequest<DeletedCarModelResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CarModelsOperationClaims.Delete];

    public class DeleteCarModelCommandHandler : IRequestHandler<DeleteCarModelCommand, DeletedCarModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;
        private readonly CarModelBusinessRules _carModelBusinessRules;

        public DeleteCarModelCommandHandler(IMapper mapper, ICarModelRepository carModelRepository,
                                         CarModelBusinessRules carModelBusinessRules)
        {
            _mapper = mapper;
            _carModelRepository = carModelRepository;
            _carModelBusinessRules = carModelBusinessRules;
        }

        public async Task<DeletedCarModelResponse> Handle(DeleteCarModelCommand request, CancellationToken cancellationToken)
        {
            CarModel? carModel = await _carModelRepository.GetAsync(predicate: cm => cm.Id == request.Id, cancellationToken: cancellationToken);
            await _carModelBusinessRules.CarModelShouldExistWhenSelected(carModel);

            await _carModelRepository.DeleteAsync(carModel!);

            DeletedCarModelResponse response = _mapper.Map<DeletedCarModelResponse>(carModel);
            return response;
        }
    }
}