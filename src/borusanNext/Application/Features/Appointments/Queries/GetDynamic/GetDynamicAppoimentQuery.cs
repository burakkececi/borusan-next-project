using Application.Features.Adverts.Queries.GetDynamic;
using Application.Features.Adverts.Rules;
using Application.Features.Appointments.Queries.GetDynamic;
using Application.Features.Appointments.Rules;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Brands.Queries.GetDynamic;

public class GetDynamicAppoimentQuery : IRequest<GetListResponse<GetDynamicAppoimentResponse>>
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }

    public class GetDynamicAppoimentQueryHandler : IRequestHandler<GetDynamicAppoimentQuery, GetListResponse<GetDynamicAppoimentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AppointmentBusinessRules _appointmentBusinessRules;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetDynamicAppoimentQueryHandler(IMapper mapper, AppointmentBusinessRules appointmentBusinessRules, IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _appointmentBusinessRules = appointmentBusinessRules;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<GetListResponse<GetDynamicAppoimentResponse>> Handle(GetDynamicAppoimentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Appointment> appoiment = await _appointmentRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                include: i => i.Include(appoiment => appoiment.Car).Include(appoiment => appoiment.Customer),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);


            GetListResponse<GetDynamicAppoimentResponse> response = _mapper.Map<GetListResponse<GetDynamicAppoimentResponse>>(appoiment);
            return response;
        }

        
    }
}
