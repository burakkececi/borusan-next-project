using Application.Features.Cars.Constants;
using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cars.Constants.CustomersOperationClaims;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCustomerCommand : IRequest<DeletedCustomerResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CustomersOperationClaims.Delete];

    public class DeleteCarCommandHandler : IRequestHandler<DeleteCustomerCommand, DeletedCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CustomerBusinessRules _carBusinessRules;

        public DeleteCarCommandHandler(IMapper mapper, ICarRepository carRepository,
                                         CustomerBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<DeletedCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _carBusinessRules.CarShouldExistWhenSelected(car);

            await _carRepository.DeleteAsync(car!);

            DeletedCustomerResponse response = _mapper.Map<DeletedCustomerResponse>(car);
            return response;
        }
    }
}