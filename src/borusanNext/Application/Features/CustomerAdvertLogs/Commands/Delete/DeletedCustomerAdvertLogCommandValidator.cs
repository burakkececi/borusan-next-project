using FluentValidation;

namespace Application.Features.CustomerAdvertLogs.Commands.Delete;

public class DeleteCustomerAdvertLogCommandValidator : AbstractValidator<DeleteCustomerAdvertLogCommand>
{
    public DeleteCustomerAdvertLogCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}