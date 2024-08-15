using Domain.Entities;
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
    public string TagName { get; set; }

    public Guid BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogDescription { get; set; }
    public string BlogBanner { get; set; }
}
