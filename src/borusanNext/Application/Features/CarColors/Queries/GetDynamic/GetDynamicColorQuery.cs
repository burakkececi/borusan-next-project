using Application.Features.BlogItemTags.Queries.GetDynamic;
using Application.Features.CarColors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarColors.Queries.GetDynamic;
public class GetDynamicColorQuery : IRequest<GetListResponse<GetDynamicColorResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicColorQueryHandler : IRequestHandler<GetDynamicColorQuery, GetListResponse<GetDynamicColorResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICarColorRepository _carColorRepository;
        private readonly CarColorBusinessRules _carColorBusinessRules;

        public GetDynamicColorQueryHandler(IMapper mapper, ICarColorRepository carColorRepository, CarColorBusinessRules carColorBusinessRules)
        {
            _mapper = mapper;
            _carColorRepository = carColorRepository;
            _carColorBusinessRules = carColorBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicColorResponse>> Handle(GetDynamicColorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CarColor> carColor = await _carColorRepository.GetListByDynamicAsync(
               dynamic: request.DynamicQuery,
               include: i => i.Include(c => c.Cars),
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);


            GetListResponse<GetDynamicColorResponse> response = _mapper.Map<GetListResponse<GetDynamicColorResponse>>(carColor);
            return response;
        }
    }
}
