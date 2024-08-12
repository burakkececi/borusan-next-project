using FluentValidation;

namespace Application.Features.Customers.Commands.Delete;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Id cannot be empty")
                          .NotEqual(Guid.Empty).WithMessage("Id cannot be empty or can be invalid.")
                          .WithName("Customer Delete Id");
    }
}