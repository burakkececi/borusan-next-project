using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdvertImages.Queries.GetByAdvertId;
public class GetByAdvertIdAdvertImageResponse:IResponse
{
    public string ImageURL { get; set; }
}
