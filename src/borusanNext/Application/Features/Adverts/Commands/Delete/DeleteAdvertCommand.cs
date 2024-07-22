using Application.Features.Adverts.Constants;
using Application.Features.Adverts.Constants;
using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;

namespace Application.Features.Adverts.Commands.Delete;

public class DeleteAdvertCommand : IRequest<DeletedAdvertResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AdvertsOperationClaims.Delete];

    public class DeleteAdvertCommandHandler : IRequestHandler<DeleteAdvertCommand, DeletedAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertRepository _advertRepository;
        private readonly AdvertBusinessRules _advertBusinessRules;

        public DeleteAdvertCommandHandler(IMapper mapper, IAdvertRepository advertRepository,
                                         AdvertBusinessRules advertBusinessRules)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
            _advertBusinessRules = advertBusinessRules;
        }

        public async Task<DeletedAdvertResponse> Handle(DeleteAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _advertBusinessRules.AdvertShouldExistWhenSelected(advert);

            await _advertRepository.DeleteAsync(advert!);

            DeletedAdvertResponse response = _mapper.Map<DeletedAdvertResponse>(advert);
            return response;
        }
    }
}