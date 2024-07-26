using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blogs.Commands.Create;

public class CreatedBlogResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Banner { get; set; }
}