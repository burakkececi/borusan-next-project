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

namespace Application.Features.AdvertImages.Commands.Update;

public class UpdateAdvertImageCommand : IRequest<UpdatedAdvertImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required Guid AdvertId { get; set; }
    public required IFormFile ImageURL { get; set; }

    public string[] Roles => [Admin, Write, AdvertImagesOperationClaims.Update];

    public class UpdateAdvertImageCommandHandler : IRequestHandler<UpdateAdvertImageCommand, UpdatedAdvertImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertImageRepository _advertImageRepository;
        private readonly AdvertImageBusinessRules _advertImageBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public UpdateAdvertImageCommandHandler(IMapper mapper, IAdvertImageRepository advertImageRepository,
                                         AdvertImageBusinessRules advertImageBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _advertImageRepository = advertImageRepository;
            _advertImageBusinessRules = advertImageBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<UpdatedAdvertImageResponse> Handle(UpdateAdvertImageCommand request, CancellationToken cancellationToken)
        {
            AdvertImage? advertImage = await _advertImageRepository.GetAsync(predicate: ai => ai.Id == request.Id, cancellationToken: cancellationToken);
            await _advertImageBusinessRules.AdvertImageShouldExistWhenSelected(advertImage);

            await _advertImageBusinessRules.AdvertIdShouldExistWhenSelected(request.AdvertId, cancellationToken);

            advertImage.ImageURL = await _imageServiceBase.UpdateAsync(request.ImageURL, advertImage.ImageURL);
            advertImage.AdvertId = request.AdvertId;

            await _advertImageRepository.UpdateAsync(advertImage!);

            UpdatedAdvertImageResponse response = _mapper.Map<UpdatedAdvertImageResponse>(advertImage);
            return response;
        }
    }
}