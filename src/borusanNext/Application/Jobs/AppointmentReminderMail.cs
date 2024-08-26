using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Customers;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Persistence.Paging;
using MimeKit;
using Microsoft.EntityFrameworkCore;
using Domain.Entities; 

public class AppointmentReminderMail
{
    private readonly IMailService _mailService;
    private readonly ICustomerService _customerService;

    private const int PageSize = 100; 

    public AppointmentReminderMail(IMailService mailService, ICustomerService customerService)
    {
        _mailService = mailService;
        _customerService = customerService;
    }

    public async Task SendAppointmentRemindersAsync()
    {
        int pageIndex = 0;
        bool hasMore = true;

        var tomorrow = DateTime.UtcNow.AddDays(1).Date;

        while (hasMore)
        {
            var paginatedAppointments = await _customerService.GetListAsync(
                predicate: c => c.Appointments.Any(a => a.DateAndTime.Date == tomorrow),
                orderBy: null,
                include: query => query.Include(c => c.Appointments)
                                       .ThenInclude(a => a.Car)
                                       .ThenInclude(d => d.ModalExtension)
                                       .ThenInclude(f => f.CarModel)
                                       .ThenInclude(g => g.Brand)
                                       .Include(c => c.User),
                index: pageIndex,
                size: PageSize
            );

            if (paginatedAppointments?.Items != null && paginatedAppointments.Items.Any())
            {
                foreach (var customer in paginatedAppointments.Items)
                {
                    var appointmentsForTomorrow = customer.Appointments
                        .Where(a => a.DateAndTime.Date == tomorrow)
                        .ToList();

                    if (!string.IsNullOrEmpty(customer.User?.Email))
                    {
                        await SendAppointmentReminderEmailAsync(customer.User.Email, customer.FirstName, appointmentsForTomorrow);
                    }
                }
            }

            hasMore = paginatedAppointments?.HasNext ?? false;
            pageIndex++;
        }
    }

    private async Task SendAppointmentReminderEmailAsync(string emailAddress, string firstName, List<Appointment> appointments)
    {
        var toEmailList = new List<MailboxAddress> { new(emailAddress, emailAddress) };

        var appointmentDetails = string.Join("<br>", appointments.Select(a =>
            $"Appointment with Brand: {a.Car.ModalExtension.CarModel.Brand.Name} Model: {a.Car.ModalExtension.CarModel.ModelName} on {a.DateAndTime.ToString("f")}"
        ));

        _mailService.SendMail(
            new Mail
            {
                ToList = toEmailList,
                Subject = "Upcoming Appointment Reminder",
                HtmlBody = $"Dear {firstName},<br><br>You have the following appointments scheduled for tomorrow:<br>{appointmentDetails}<br><br>Best regards,<br>Your Company"
            }
        );
    }
}
