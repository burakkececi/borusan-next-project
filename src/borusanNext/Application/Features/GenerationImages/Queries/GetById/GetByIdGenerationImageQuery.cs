using Application.Features.GenerationImages.Constants;
using Application.Features.GenerationImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.GenerationImages.Constants.GenerationImagesOperationClaims;

namespace Application.Features.GenerationImages.Queries.GetById;

public class GetByIdGenerationImageQuery : IRequest<GetByIdGenerationImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdGenerationImageQueryHandler : IRequestHandler<GetByIdGenerationImageQuery, GetByIdGenerationImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationImageRepository _generationImageRepository;
        private readonly GenerationImageBusinessRules _generationImageBusinessRules;

        public GetByIdGenerationImageQueryHandler(IMapper mapper, IGenerationImageRepository generationImageRepository, GenerationImageBusinessRules generationImageBusinessRules)
        {
            _mapper = mapper;
            _generationImageRepository = generationImageRepository;
            _generationImageBusinessRules = generationImageBusinessRules;
        }

        public async Task<GetByIdGenerationImageResponse> Handle(GetByIdGenerationImageQuery request, CancellationToken cancellationToken)
        {
            GenerationImage? generationImage = await _generationImageRepository.GetAsync(predicate: gi => gi.Id == request.Id, cancellationToken: cancellationToken);
            await _generationImageBusinessRules.GenerationImageShouldExistWhenSelected(generationImage);

            GetByIdGenerationImageResponse response = _mapper.Map<GetByIdGenerationImageResponse>(generationImage);
            return response;
        }
    }
}