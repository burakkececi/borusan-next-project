using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Application.Features.AdvertImages.Commands.Create
{
    public class CreateAdvertImageCommandValidator : AbstractValidator<CreateAdvertImageCommand>
    {
        public CreateAdvertImageCommandValidator()
        {
            RuleFor(c => c.AdvertId)
                .NotNull().WithMessage("Advert ID cannot be null.")
                .NotEmpty().WithMessage("Advert ID cannot be empty.")
                .Must(BeAValidGuid).WithMessage("Advert ID must be a valid GUID.");

            RuleFor(c => c.ImageURL)
                .NotNull().WithMessage("Image URL cannot be null.")
                .Must(BeAValidFile).WithMessage("Image URL must be a valid file with a supported image format.")
                .Must(HaveValidImageExtension).WithMessage("Image URL must be a valid image file ending in .jpg, .jpeg, or .png.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }

        private bool BeAValidFile(IFormFile file)
        {
            return file != null && file.Length > 0;
        }

        private bool HaveValidImageExtension(IFormFile file)
        {
            var validExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return !string.IsNullOrEmpty(fileExtension) && validExtensions.Contains(fileExtension);
        }
    }
}
