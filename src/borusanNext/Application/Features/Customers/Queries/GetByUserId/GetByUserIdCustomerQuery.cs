using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.Customers.Constants.CustomersOperationClaims;

namespace Application.Features.Customers.Queries.GetByUserId
{
    public class GetByUserIdCustomerQuery : IRequest<GetByUserIdCustomerResponse>, ISecuredRequest
    {
        public Guid UserId { get; set; }

        public string[] Roles => new[] { Admin, Read };
    }

    public class GetByUserIdCustomerFavoriteQueryHandler : IRequestHandler<GetByUserIdCustomerQuery, GetByUserIdCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public GetByUserIdCustomerFavoriteQueryHandler(IMapper mapper, ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<GetByUserIdCustomerResponse> Handle(GetByUserIdCustomerQuery request, CancellationToken cancellationToken)
        {
            Customer? customer = await _customerRepository.GetAsync(predicate: c => c.UserId == request.UserId, cancellationToken: cancellationToken);
            await _customerBusinessRules.CustomerShouldExistWhenSelected(customer);

            GetByUserIdCustomerResponse response = _mapper.Map<GetByUserIdCustomerResponse>(customer);
            return response;
        }
    }
}
