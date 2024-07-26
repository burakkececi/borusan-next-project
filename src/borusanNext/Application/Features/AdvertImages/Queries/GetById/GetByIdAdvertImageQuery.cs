using Application.Features.AdvertImages.Constants;
using Application.Features.AdvertImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AdvertImages.Constants.AdvertImagesOperationClaims;

namespace Application.Features.AdvertImages.Queries.GetById;

public class GetByIdAdvertImageQuery : IRequest<GetByIdAdvertImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAdvertImageQueryHandler : IRequestHandler<GetByIdAdvertImageQuery, GetByIdAdvertImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertImageRepository _advertImageRepository;
        private readonly AdvertImageBusinessRules _advertImageBusinessRules;

        public GetByIdAdvertImageQueryHandler(IMapper mapper, IAdvertImageRepository advertImageRepository, AdvertImageBusinessRules advertImageBusinessRules)
        {
            _mapper = mapper;
            _advertImageRepository = advertImageRepository;
            _advertImageBusinessRules = advertImageBusinessRules;
        }

        public async Task<GetByIdAdvertImageResponse> Handle(GetByIdAdvertImageQuery request, CancellationToken cancellationToken)
        {
            AdvertImage? advertImage = await _advertImageRepository.GetAsync(predicate: ai => ai.Id == request.Id, cancellationToken: cancellationToken);
            await _advertImageBusinessRules.AdvertImageShouldExistWhenSelected(advertImage);

            GetByIdAdvertImageResponse response = _mapper.Map<GetByIdAdvertImageResponse>(advertImage);
            return response;
        }
    }
}