using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerFavorites.Queries.GetByCustomerId;
public class GetByCustomerIdCustomerFavoriteListItemDto
{
    public string AdvertId { get; set; }
    public string ImageURL { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public int ModelYear { get; set; }
    public int Kilometers { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
}
