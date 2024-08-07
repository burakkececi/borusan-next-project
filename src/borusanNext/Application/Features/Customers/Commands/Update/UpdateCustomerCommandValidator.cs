using FluentValidation;

namespace Application.Features.Customers.Commands.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be empty or can be invalid.")
            .WithName("Customer Update Id");

        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("UserId cannot be empty or invalid")
            .WithName("Customer Update User Id");

        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("FirstName cannot be empty")
            .MinimumLength(3).WithMessage("FirstName length must be at least 3")
            .MaximumLength(100).WithMessage("FirstName length can be up to 100")
            .WithName("Customer Update FirstName");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("LastName cannot be empty")
            .MinimumLength(3).WithMessage("LastName length must be at least 3")
            .MaximumLength(100).WithMessage("LastName length can be up to 100")
            .WithName("Customer Update LastName");

        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Phone cannot be empty")
            .Matches(@"^(0\d{3} \d{3} \d{2} \d{2})$").WithMessage("Phone number is not valid")
            .WithName("Customer Update Phone");

        RuleFor(c => c.CustomerType)
            .NotEmpty().WithMessage("CustomerType cannot be empty")
            .IsInEnum().WithMessage("CustomerType should be between 0 and 4")
            .WithName("Customer Update CustomerType");
    }
}