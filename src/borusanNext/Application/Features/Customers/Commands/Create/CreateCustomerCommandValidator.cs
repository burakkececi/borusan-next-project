using Domain.Enums;
using FluentValidation;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("UserId cannot be empty or invalid")
            .WithName("Customer Create User Id");

        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("FirstName cannot be empty")
            .MinimumLength(3).WithMessage("FirstName length must be at least 3")
            .MaximumLength(100).WithMessage("FirstName length can be up to 100")
            .WithName("Customer Create FirstName");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("LastName cannot be empty")
            .MinimumLength(3).WithMessage("LastName length must be at least 3")
            .MaximumLength(100).WithMessage("LastName length can be up to 100")
            .WithName("Customer Create LastName");

        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Phone cannot be empty")
            .Matches(@"^(0\d{3} \d{3} \d{2} \d{2})$").WithMessage("Phone number is not valid")
            .WithName("Customer Create Phone");

        RuleFor(c => c.CustomerType)
            .NotEmpty().WithMessage("CustomerType cannot be empty")
            .IsInEnum().WithMessage("CustomerType should be between 0 and 4")
            .WithName("Customer Create CustomerType");

    }
}