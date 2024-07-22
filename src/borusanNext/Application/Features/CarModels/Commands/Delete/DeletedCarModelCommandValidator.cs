using FluentValidation;

namespace Application.Features.CarModels.Commands.Delete;

public class DeleteCarModelCommandValidator : AbstractValidator<DeleteCarModelCommand>
{
    public DeleteCarModelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}