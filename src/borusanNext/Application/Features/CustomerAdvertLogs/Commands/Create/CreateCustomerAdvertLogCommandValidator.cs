using FluentValidation;

namespace Application.Features.CustomerAdvertLogs.Commands.Create;

public class CreateCustomerAdvertLogCommandValidator : AbstractValidator<CreateCustomerAdvertLogCommand>
{
    public CreateCustomerAdvertLogCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.ContactStatus).NotEmpty();
    }
}