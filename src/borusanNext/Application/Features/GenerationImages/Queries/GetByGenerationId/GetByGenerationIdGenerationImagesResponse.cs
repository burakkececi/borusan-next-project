using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GenerationImages.Queries.GetByGenerationId;
public class GetByGenerationIdGenerationImagesResponse:IResponse
{
    public string ImageURL { get; set; }
}
