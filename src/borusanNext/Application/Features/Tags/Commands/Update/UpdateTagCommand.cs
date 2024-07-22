using Application.Features.Tags.Constants;
using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Tags.Constants.TagsOperationClaims;

namespace Application.Features.Tags.Commands.Update;

public class UpdateTagCommand : IRequest<UpdatedTagResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, TagsOperationClaims.Update];

    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, UpdatedTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public UpdateTagCommandHandler(IMapper mapper, ITagRepository tagRepository,
                                         TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<UpdatedTagResponse> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            Tag? tag = await _tagRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tagBusinessRules.TagShouldExistWhenSelected(tag);
            tag = _mapper.Map(request, tag);

            await _tagRepository.UpdateAsync(tag!);

            UpdatedTagResponse response = _mapper.Map<UpdatedTagResponse>(tag);
            return response;
        }
    }
}