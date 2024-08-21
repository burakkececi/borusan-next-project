using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Customers.Constants.CustomersOperationClaims;


namespace Application.Features.Customers.Queries.GetDynamic;
public class GetDynamicCustomerQuery : IRequest<GetListResponse<GetDynamicCustomerResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicCustomerQueryHandler : IRequestHandler<GetDynamicCustomerQuery, GetListResponse<GetDynamicCustomerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public GetDynamicCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicCustomerResponse>> Handle(GetDynamicCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Customer> customer = await _customerRepository.GetListByDynamicAsync(
             dynamic: request.DynamicQuery,
             index: request.PageRequest.PageIndex,
             include: i => i
                 .Include(c => c.CustomerFavorites).Include(c => c.Appointments).Include(c => c.CustomerAdvertLogs),
             size: request.PageRequest.PageSize,
             cancellationToken: cancellationToken);


            GetListResponse<GetDynamicCustomerResponse> response = _mapper.Map<GetListResponse<GetDynamicCustomerResponse>>(customer);
            return response;
        }
    }
}
