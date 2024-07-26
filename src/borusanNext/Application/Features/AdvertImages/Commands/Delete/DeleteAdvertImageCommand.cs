using Application.Features.AdvertImages.Constants;
using Application.Features.AdvertImages.Constants;
using Application.Features.AdvertImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AdvertImages.Constants.AdvertImagesOperationClaims;

namespace Application.Features.AdvertImages.Commands.Delete;

public class DeleteAdvertImageCommand : IRequest<DeletedAdvertImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AdvertImagesOperationClaims.Delete];

    public class DeleteAdvertImageCommandHandler : IRequestHandler<DeleteAdvertImageCommand, DeletedAdvertImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertImageRepository _advertImageRepository;
        private readonly AdvertImageBusinessRules _advertImageBusinessRules;

        public DeleteAdvertImageCommandHandler(IMapper mapper, IAdvertImageRepository advertImageRepository,
                                         AdvertImageBusinessRules advertImageBusinessRules)
        {
            _mapper = mapper;
            _advertImageRepository = advertImageRepository;
            _advertImageBusinessRules = advertImageBusinessRules;
        }

        public async Task<DeletedAdvertImageResponse> Handle(DeleteAdvertImageCommand request, CancellationToken cancellationToken)
        {
            AdvertImage? advertImage = await _advertImageRepository.GetAsync(predicate: ai => ai.Id == request.Id, cancellationToken: cancellationToken);
            await _advertImageBusinessRules.AdvertImageShouldExistWhenSelected(advertImage);

            await _advertImageRepository.DeleteAsync(advertImage!);

            DeletedAdvertImageResponse response = _mapper.Map<DeletedAdvertImageResponse>(advertImage);
            return response;
        }
    }
}