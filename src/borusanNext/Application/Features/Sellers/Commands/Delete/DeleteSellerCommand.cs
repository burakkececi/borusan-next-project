using Application.Features.Sellers.Constants;
using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Sellers.Constants.SellersOperationClaims;

namespace Application.Features.Sellers.Commands.Delete;

public class DeleteSellerCommand : IRequest<DeletedSellerResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, SellersOperationClaims.Delete];

    public class DeleteSellerCommandHandler : IRequestHandler<DeleteSellerCommand, DeletedSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly SellerBusinessRules _sellerBusinessRules;

        public DeleteSellerCommandHandler(IMapper mapper, ISellerRepository sellerRepository,
                                         SellerBusinessRules sellerBusinessRules)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            _sellerBusinessRules = sellerBusinessRules;
        }

        public async Task<DeletedSellerResponse> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
        {
            Seller? seller = await _sellerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sellerBusinessRules.SellerShouldExistWhenSelected(seller);

            await _sellerRepository.DeleteAsync(seller!);

            DeletedSellerResponse response = _mapper.Map<DeletedSellerResponse>(seller);
            return response;
        }
    }
}