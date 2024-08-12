using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeAValidGuid).WithMessage("Id must be a non-empty GUID.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(c => c.Logo)
                .NotEmpty().WithMessage("Logo cannot be empty.")
                .Must(BeAValidImage).WithMessage("Logo must be a valid image file.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
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
