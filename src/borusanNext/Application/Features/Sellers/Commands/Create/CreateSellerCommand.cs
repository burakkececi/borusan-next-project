using Application.Features.Sellers.Constants;
using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Sellers.Constants.SellersOperationClaims;

namespace Application.Features.Sellers.Commands.Create;

public class CreateSellerCommand : IRequest<CreatedSellerResponse>, ISecuredRequest
{
    public required Guid UserId { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public required Guid LicenceId { get; set; }
    public required Guid LocationId { get; set; }

    public string[] Roles => [Admin, Write, SellersOperationClaims.Create];

    public class CreateSellerCommandHandler : IRequestHandler<CreateSellerCommand, CreatedSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly SellerBusinessRules _sellerBusinessRules;

        public CreateSellerCommandHandler(IMapper mapper, ISellerRepository sellerRepository,
                                         SellerBusinessRules sellerBusinessRules)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            _sellerBusinessRules = sellerBusinessRules;
        }

        public async Task<CreatedSellerResponse> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            Seller seller = _mapper.Map<Seller>(request);
            await _sellerBusinessRules.UserIdShouldExistWhenBindingToSeller(seller.UserId, cancellationToken);
            await _sellerBusinessRules.LocationIdShouldExistWhenBindingToSeller(seller.LocationId, cancellationToken);
            await _sellerBusinessRules.LicenceIdShouldExistWhenBindingToSeller(seller.LicenceId, cancellationToken);

            await _sellerRepository.AddAsync(seller);

            CreatedSellerResponse response = _mapper.Map<CreatedSellerResponse>(seller);
            return response;
        }
    }
}