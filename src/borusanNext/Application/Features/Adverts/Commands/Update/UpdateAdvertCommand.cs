using Application.Features.Adverts.Constants;
using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;

namespace Application.Features.Adverts.Commands.Update;

public class UpdateAdvertCommand : IRequest<UpdatedAdvertResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required int AdvertNo { get; set; }
    public required DateTime PublishedDate { get; set; }
    public required Guid CarId { get; set; }

    public string[] Roles => [Admin, Write, AdvertsOperationClaims.Update];

    public class UpdateAdvertCommandHandler : IRequestHandler<UpdateAdvertCommand, UpdatedAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertRepository _advertRepository;
        private readonly AdvertBusinessRules _advertBusinessRules;

        public UpdateAdvertCommandHandler(IMapper mapper, IAdvertRepository advertRepository,
                                         AdvertBusinessRules advertBusinessRules)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
            _advertBusinessRules = advertBusinessRules;
        }

        public async Task<UpdatedAdvertResponse> Handle(UpdateAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            advert.CreatedDate = DateTime.Now;
            await _advertBusinessRules.AdvertShouldExistWhenSelected(advert);
            advert = _mapper.Map(request, advert);

            await _advertRepository.UpdateAsync(advert!);

            UpdatedAdvertResponse response = _mapper.Map<UpdatedAdvertResponse>(advert);
            return response;
        }
    }
}