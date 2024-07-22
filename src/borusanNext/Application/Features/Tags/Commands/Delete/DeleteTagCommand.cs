using Application.Features.Tags.Constants;
using Application.Features.Tags.Constants;
using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Tags.Constants.TagsOperationClaims;

namespace Application.Features.Tags.Commands.Delete;

public class DeleteTagCommand : IRequest<DeletedTagResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TagsOperationClaims.Delete];

    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, DeletedTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public DeleteTagCommandHandler(IMapper mapper, ITagRepository tagRepository,
                                         TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<DeletedTagResponse> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            Tag? tag = await _tagRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tagBusinessRules.TagShouldExistWhenSelected(tag);

            await _tagRepository.DeleteAsync(tag!);

            DeletedTagResponse response = _mapper.Map<DeletedTagResponse>(tag);
            return response;
        }
    }
}