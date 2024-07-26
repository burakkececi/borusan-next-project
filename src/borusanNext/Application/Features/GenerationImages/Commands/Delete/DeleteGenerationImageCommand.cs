using Application.Features.GenerationImages.Constants;
using Application.Features.GenerationImages.Constants;
using Application.Features.GenerationImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.GenerationImages.Constants.GenerationImagesOperationClaims;

namespace Application.Features.GenerationImages.Commands.Delete;

public class DeleteGenerationImageCommand : IRequest<DeletedGenerationImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, GenerationImagesOperationClaims.Delete];

    public class DeleteGenerationImageCommandHandler : IRequestHandler<DeleteGenerationImageCommand, DeletedGenerationImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationImageRepository _generationImageRepository;
        private readonly GenerationImageBusinessRules _generationImageBusinessRules;

        public DeleteGenerationImageCommandHandler(IMapper mapper, IGenerationImageRepository generationImageRepository,
                                         GenerationImageBusinessRules generationImageBusinessRules)
        {
            _mapper = mapper;
            _generationImageRepository = generationImageRepository;
            _generationImageBusinessRules = generationImageBusinessRules;
        }

        public async Task<DeletedGenerationImageResponse> Handle(DeleteGenerationImageCommand request, CancellationToken cancellationToken)
        {
            GenerationImage? generationImage = await _generationImageRepository.GetAsync(predicate: gi => gi.Id == request.Id, cancellationToken: cancellationToken);
            await _generationImageBusinessRules.GenerationImageShouldExistWhenSelected(generationImage);

            await _generationImageRepository.DeleteAsync(generationImage!);

            DeletedGenerationImageResponse response = _mapper.Map<DeletedGenerationImageResponse>(generationImage);
            return response;
        }
    }
}