using Application.Features.Brands.Constants;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Brands.Constants.BrandsOperationClaims;
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required IFormFile Logo { get; set; }

    public string[] Roles => [Admin, Write, BrandsOperationClaims.Update];

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository,
                                         BrandBusinessRules brandBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _brandBusinessRules = brandBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _brandBusinessRules.BrandShouldExistWhenSelected(brand);

            brand.Logo = await _imageServiceBase.UpdateAsync(request.Logo, brand.Logo);
            brand.Name = request.Name;

            await _brandRepository.UpdateAsync(brand!);

            UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);
            return response;
        }
    }
}