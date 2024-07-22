using FluentValidation;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}