using Application.Features.CarModels.Constants;
using Application.Features.CarModels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarModels.Constants.CarModelsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CarModels.Queries.GetById;

public class GetByIdCarModelQuery : IRequest<GetByIdCarModelResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCarModelQueryHandler : IRequestHandler<GetByIdCarModelQuery, GetByIdCarModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;
        private readonly CarModelBusinessRules _carModelBusinessRules;

        public GetByIdCarModelQueryHandler(IMapper mapper, ICarModelRepository carModelRepository, CarModelBusinessRules carModelBusinessRules)
        {
            _mapper = mapper;
            _carModelRepository = carModelRepository;
            _carModelBusinessRules = carModelBusinessRules;
        }

        public async Task<GetByIdCarModelResponse> Handle(GetByIdCarModelQuery request, CancellationToken cancellationToken)
        {
            CarModel? carModel = await _carModelRepository.GetAsync(predicate: cm => cm.Id == request.Id, include: i => i.Include(c => c.Brand), cancellationToken: cancellationToken);
            await _carModelBusinessRules.CarModelShouldExistWhenSelected(carModel);

            GetByIdCarModelResponse response = _mapper.Map<GetByIdCarModelResponse>(carModel);
            return response;
        }
    }
}