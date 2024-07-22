using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cars.Constants.CustomersOperationClaims;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCustomerQuery : IRequest<GetByIdCarResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetByIdCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CustomerBusinessRules _carBusinessRules;

        public GetByIdCarQueryHandler(IMapper mapper, ICarRepository carRepository, CustomerBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<GetByIdCarResponse> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _carBusinessRules.CarShouldExistWhenSelected(car);

            GetByIdCarResponse response = _mapper.Map<GetByIdCarResponse>(car);
            return response;
        }
    }
}