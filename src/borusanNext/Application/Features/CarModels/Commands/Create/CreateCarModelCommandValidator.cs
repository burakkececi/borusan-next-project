using FluentValidation;

namespace Application.Features.CarModels.Commands.Create;

public class CreateCarModelCommandValidator : AbstractValidator<CreateCarModelCommand>
{
    public CreateCarModelCommandValidator()
    {
        RuleFor(c => c.ModelName).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
    }
}