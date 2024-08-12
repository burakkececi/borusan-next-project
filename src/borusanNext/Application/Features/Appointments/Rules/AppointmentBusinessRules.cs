using Application.Features.Appointments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Appointments.Rules;

public class AppointmentBusinessRules : BaseBusinessRules
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly ICarRepository _carRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ILocalizationService _localizationService;

    public AppointmentBusinessRules(
        IAppointmentRepository appointmentRepository,
        ICarRepository carRepository,
        ICustomerRepository customerRepository,
        ILocalizationService localizationService
    )
    {
        _appointmentRepository = appointmentRepository;
        _carRepository = carRepository;
        _customerRepository = customerRepository; 
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AppointmentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AppointmentShouldExistWhenSelected(Appointment? appointment)
    {
        if (appointment == null)
            await throwBusinessException(AppointmentsBusinessMessages.AppointmentNotExists);
    }

    public async Task AppointmentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Appointment? appointment = await _appointmentRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AppointmentShouldExistWhenSelected(appointment);
    }

    public async Task CarIdShouldExistWhenSelected(Guid carId, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(
            predicate: c => c.Id == carId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (car == null)
        {
            string messageKey = AppointmentsBusinessMessages.CarNotExists; 
            await throwBusinessException(messageKey);
        }
    }

    public async Task CustomerIdShouldExistWhenSelected(Guid customerId, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(
            predicate: c => c.Id == customerId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (customer == null)
        {
            string messageKey = AppointmentsBusinessMessages.CustomerNotExists; 
            await throwBusinessException(messageKey);
        }
    }
}
