using Application.Features.AdvertImages.Constants;
using Application.Features.AdvertImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AdvertImages.Constants.AdvertImagesOperationClaims;
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.AdvertImages.Commands.Create;

public class CreateAdvertImageCommand : IRequest<CreatedAdvertImageResponse>, ISecuredRequest
{
    public required Guid AdvertId { get; set; }
    public required IFormFile ImageURL { get; set; }

    public string[] Roles => [Admin, Write, AdvertImagesOperationClaims.Create];

    public class CreateAdvertImageCommandHandler : IRequestHandler<CreateAdvertImageCommand, CreatedAdvertImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertImageRepository _advertImageRepository;
        private readonly AdvertImageBusinessRules _advertImageBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public CreateAdvertImageCommandHandler(IMapper mapper, IAdvertImageRepository advertImageRepository,
                                         AdvertImageBusinessRules advertImageBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _advertImageRepository = advertImageRepository;
            _advertImageBusinessRules = advertImageBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<CreatedAdvertImageResponse> Handle(CreateAdvertImageCommand request, CancellationToken cancellationToken)
        {
            AdvertImage advertImage = _mapper.Map<AdvertImage>(request);

            advertImage.ImageURL = await _imageServiceBase.UploadAsync(request.ImageURL);

            await _advertImageRepository.AddAsync(advertImage);

            CreatedAdvertImageResponse response = _mapper.Map<CreatedAdvertImageResponse>(advertImage);
            return response;
        }
    }
}