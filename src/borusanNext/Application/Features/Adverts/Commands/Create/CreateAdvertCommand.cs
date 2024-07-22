using Application.Features.Adverts.Constants;
using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;

namespace Application.Features.Adverts.Commands.Create;

public class CreateAdvertCommand : IRequest<CreatedAdvertResponse>, ISecuredRequest
{
    public required int AdvertNo { get; set; }
    public required DateTime PublishedDate { get; set; }
    public required Guid CarId { get; set; }

    public string[] Roles => [Admin, Write, AdvertsOperationClaims.Create];

    public class CreateAdvertCommandHandler : IRequestHandler<CreateAdvertCommand, CreatedAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertRepository _advertRepository;
        private readonly AdvertBusinessRules _advertBusinessRules;

        public CreateAdvertCommandHandler(IMapper mapper, IAdvertRepository advertRepository,
                                         AdvertBusinessRules advertBusinessRules)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
            _advertBusinessRules = advertBusinessRules;
        }

        public async Task<CreatedAdvertResponse> Handle(CreateAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = _mapper.Map<Advert>(request);

            await _advertRepository.AddAsync(advert);

            CreatedAdvertResponse response = _mapper.Map<CreatedAdvertResponse>(advert);
            return response;
        }
    }
}