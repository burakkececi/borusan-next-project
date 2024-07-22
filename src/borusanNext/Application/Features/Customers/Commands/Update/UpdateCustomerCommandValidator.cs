using FluentValidation;

namespace Application.Features.Customers.Commands.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.EmailAddress).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.IsSmsConfirmed).NotEmpty();
        RuleFor(c => c.CustomerType).NotEmpty();
    }
}