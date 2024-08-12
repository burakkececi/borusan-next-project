using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;

namespace Application.Features.Appointments.Commands.Create;

public class CreateAppointmentCommand : IRequest<CreatedAppointmentResponse>, ISecuredRequest
{
    public required DateTime DateAndTime { get; set; }
    public required Guid CarId { get; set; }
    public required Guid CustomerId { get; set; }

    public string[] Roles => [Admin, Write, AppointmentsOperationClaims.Create];

    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreatedAppointmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly AppointmentBusinessRules _appointmentBusinessRules;

        public CreateAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository,
                                         AppointmentBusinessRules appointmentBusinessRules)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _appointmentBusinessRules = appointmentBusinessRules;
        }

        public async Task<CreatedAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            Appointment appointment = _mapper.Map<Appointment>(request);
            await _appointmentBusinessRules.CarIdShouldExistWhenSelected(request.CarId, cancellationToken);
            await _appointmentBusinessRules.CustomerIdShouldExistWhenSelected(request.CustomerId, cancellationToken);

            await _appointmentRepository.AddAsync(appointment);

            CreatedAppointmentResponse response = _mapper.Map<CreatedAppointmentResponse>(appointment);
            return response;
        }
    }
}