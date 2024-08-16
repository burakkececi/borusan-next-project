using Application.Features.Licences.Queries.GetDynamic;
using Application.Features.ModalExtensions.Rules;
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

namespace Application.Features.ModalExtensions.Queries.GetDynamic;
public class GetDynamicModalExtensionsQuery:IRequest<GetListResponse<GetDynamicModalExtensionsResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicModalExtensionsQueryHandler : IRequestHandler<GetDynamicModalExtensionsQuery, GetListResponse<GetDynamicModalExtensionsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IModalExtensionRepository _modalExtensionRepository;
        private readonly ModalExtensionBusinessRules _modalExtensionBusinessRules;

        public GetDynamicModalExtensionsQueryHandler(IMapper mapper, IModalExtensionRepository modalExtensionRepository, ModalExtensionBusinessRules modalExtensionBusinessRules)
        {
            _mapper = mapper;
            _modalExtensionRepository = modalExtensionRepository;
            _modalExtensionBusinessRules = modalExtensionBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicModalExtensionsResponse>> Handle(GetDynamicModalExtensionsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ModalExtension> modalExtension = await _modalExtensionRepository.GetListByDynamicAsync(
             dynamic: request.DynamicQuery,
             include:i=>i.Include(m=>m.Generation).Include(m => m.CarModel).ThenInclude(m => m.Brand),
             index: request.PageRequest.PageIndex,
             size: request.PageRequest.PageSize,
             cancellationToken: cancellationToken);


            GetListResponse<GetDynamicModalExtensionsResponse> response = _mapper.Map<GetListResponse<GetDynamicModalExtensionsResponse>>(modalExtension);
            return response;
        }
    }
}
