using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogItemTags.Queries.GetDynamic;
public class GetDynamicBlogItemResponse:IResponse
{
    public Guid Id { get; set; }
    public Guid TagId { get; set; }
    public Guid BlogId { get; set; }
}
