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

public class BirthdayMail
{
    private readonly IMailService _mailService;
    private readonly ICustomerService _customerService;

    private const int PageSize = 100;

    public BirthdayMail(IMailService mailService, ICustomerService customerService)
    {
        _mailService = mailService;
        _customerService = customerService;
    }

    public async Task SendBirthdayEmailsAsync()
    {
        int pageIndex = 0;
        bool hasMore = true;

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        while (hasMore)
        {
            var paginatedCustomers = await _customerService.GetListAsync(
                predicate: c => c.DateOfBirth.Month == today.Month && c.DateOfBirth.Day == today.Day,
                orderBy: null,
                include: query => query.Include(c => c.User),
                index: pageIndex,
                size: PageSize
            );

            if (paginatedCustomers?.Items != null && paginatedCustomers.Items.Any())
            {
                foreach (var customer in paginatedCustomers.Items)
                {
                    if (!string.IsNullOrEmpty(customer.User?.Email))
                    {
                        await SendBirthdayEmailAsync(customer.User.Email, customer.FirstName);
                    }
                }
            }
            hasMore = paginatedCustomers?.HasNext ?? false;
            pageIndex++;
        }
    }

    private async Task SendBirthdayEmailAsync(string emailAddress, string firstName)
    {
        var toEmailList = new List<MailboxAddress> { new(emailAddress, emailAddress) };
        _mailService.SendMail(
            new Mail
            {
                ToList = toEmailList,
                Subject = "Happy Birthday!",
                HtmlBody = $"Dear {firstName},<br><br>Wishing you a very Happy Birthday!<br><br>Best wishes,<br>Your Company"
            }
        );
    }
}
