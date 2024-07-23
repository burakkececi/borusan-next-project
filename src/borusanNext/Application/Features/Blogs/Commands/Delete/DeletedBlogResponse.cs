using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blogs.Commands.Delete;

public class DeletedBlogResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
}