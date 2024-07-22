using Application.Features.Sellers.Constants;
using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Sellers.Constants.SellersOperationClaims;

namespace Application.Features.Sellers.Commands.Update;

public class UpdateSellerCommand : IRequest<UpdatedSellerResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required int UserId { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public required Guid LicenceId { get; set; }
    public required Guid LocationId { get; set; }

    public string[] Roles => [Admin, Write, SellersOperationClaims.Update];

    public class UpdateSellerCommandHandler : IRequestHandler<UpdateSellerCommand, UpdatedSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly SellerBusinessRules _sellerBusinessRules;

        public UpdateSellerCommandHandler(IMapper mapper, ISellerRepository sellerRepository,
                                         SellerBusinessRules sellerBusinessRules)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            _sellerBusinessRules = sellerBusinessRules;
        }

        public async Task<UpdatedSellerResponse> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
        {
            Seller? seller = await _sellerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sellerBusinessRules.SellerShouldExistWhenSelected(seller);
            seller = _mapper.Map(request, seller);

            await _sellerRepository.UpdateAsync(seller!);

            UpdatedSellerResponse response = _mapper.Map<UpdatedSellerResponse>(seller);
            return response;
        }
    }
}