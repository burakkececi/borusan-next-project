using Application.Features.GenerationImages.Constants;
using Application.Features.GenerationImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.GenerationImages.Constants.GenerationImagesOperationClaims;
using Application.Services.ImageService;
using Microsoft.AspNetCore.Http;

namespace Application.Features.GenerationImages.Commands.Update;

public class UpdateGenerationImageCommand : IRequest<UpdatedGenerationImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required Guid GenerationId { get; set; }
    public IFormFile ImageURL { get; set; }

    public string[] Roles => [Admin, Write, GenerationImagesOperationClaims.Update];

    public class UpdateGenerationImageCommandHandler : IRequestHandler<UpdateGenerationImageCommand, UpdatedGenerationImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationImageRepository _generationImageRepository;
        private readonly GenerationImageBusinessRules _generationImageBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public UpdateGenerationImageCommandHandler(IMapper mapper, IGenerationImageRepository generationImageRepository,
                                         GenerationImageBusinessRules generationImageBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _generationImageRepository = generationImageRepository;
            _generationImageBusinessRules = generationImageBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<UpdatedGenerationImageResponse> Handle(UpdateGenerationImageCommand request, CancellationToken cancellationToken)
        {
            GenerationImage? generationImage = await _generationImageRepository.GetAsync(predicate: gi => gi.Id == request.Id, cancellationToken: cancellationToken);
            await _generationImageBusinessRules.GenerationImageShouldExistWhenSelected(generationImage);
            generationImage = _mapper.Map(request, generationImage);

            generationImage.ImageURL = await _imageServiceBase.UpdateAsync(request.ImageURL, generationImage.ImageURL);

            await _generationImageRepository.UpdateAsync(generationImage!);

            UpdatedGenerationImageResponse response = _mapper.Map<UpdatedGenerationImageResponse>(generationImage);
            return response;
        }
    }
}