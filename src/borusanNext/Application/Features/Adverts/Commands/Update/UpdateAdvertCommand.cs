using Application.Features.Adverts.Constants;
using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.Adverts.Commands.Update;

public class UpdateAdvertCommand : IRequest<UpdatedAdvertResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required int AdvertNo { get; set; }
    public required Guid CarId { get; set; }

    public string[] Roles => [Admin, Write, AdvertsOperationClaims.Update];

    public class UpdateAdvertCommandHandler : IRequestHandler<UpdateAdvertCommand, UpdatedAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertRepository _advertRepository;
        private readonly AdvertBusinessRules _advertBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public UpdateAdvertCommandHandler(IMapper mapper, IAdvertRepository advertRepository,
                                         AdvertBusinessRules advertBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
            _advertBusinessRules = advertBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<UpdatedAdvertResponse> Handle(UpdateAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _advertBusinessRules.AdvertShouldExistWhenSelected(advert);
            
            advert.AdvertNo = request.AdvertNo;
            advert.CarId = request.CarId; 

            await _advertRepository.UpdateAsync(advert!);

            UpdatedAdvertResponse response = _mapper.Map<UpdatedAdvertResponse>(advert);
            return response;
        }
    }
}