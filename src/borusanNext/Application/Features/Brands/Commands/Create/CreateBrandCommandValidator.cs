using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(c => c.Logo)
                .NotNull().WithMessage("Logo cannot be null.")
                .Must(BeAValidImage).WithMessage("Logo must be a valid image file.")
                .WithMessage("Logo file is required.");

        }

        private bool BeAValidImage(IFormFile logo)
        {
            if (logo == null || logo.Length == 0)
                return false;
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            string fileExtension = Path.GetExtension(logo.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
                return false;

            return true;
        }
    }
}
