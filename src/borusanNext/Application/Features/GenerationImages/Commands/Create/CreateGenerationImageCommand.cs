using Application.Features.GenerationImages.Constants;
using Application.Features.GenerationImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.GenerationImages.Constants.GenerationImagesOperationClaims;
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.GenerationImages.Commands.Create;

public class CreateGenerationImageCommand : IRequest<CreatedGenerationImageResponse>, ISecuredRequest
{
    public required Guid GenerationId { get; set; }
    public required IFormFile ImageURL { get; set; }

    public string[] Roles => [Admin, Write, GenerationImagesOperationClaims.Create];

    public class CreateGenerationImageCommandHandler : IRequestHandler<CreateGenerationImageCommand, CreatedGenerationImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationImageRepository _generationImageRepository;
        private readonly GenerationImageBusinessRules _generationImageBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;


        public CreateGenerationImageCommandHandler(IMapper mapper, IGenerationImageRepository generationImageRepository,
                                         GenerationImageBusinessRules generationImageBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _generationImageRepository = generationImageRepository;
            _generationImageBusinessRules = generationImageBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<CreatedGenerationImageResponse> Handle(CreateGenerationImageCommand request, CancellationToken cancellationToken)
        {
            GenerationImage generationImage = _mapper.Map<GenerationImage>(request);

            generationImage.ImageURL = await _imageServiceBase.UploadAsync(request.ImageURL);

            await _generationImageRepository.AddAsync(generationImage);

            CreatedGenerationImageResponse response = _mapper.Map<CreatedGenerationImageResponse>(generationImage);
            return response;
        }
    }
}