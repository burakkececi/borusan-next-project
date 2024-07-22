using FluentValidation;

namespace Application.Features.CustomerAdvertLogs.Commands.Update;

public class UpdateCustomerAdvertLogCommandValidator : AbstractValidator<UpdateCustomerAdvertLogCommand>
{
    public UpdateCustomerAdvertLogCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.ContactStatus).NotEmpty();
    }
}