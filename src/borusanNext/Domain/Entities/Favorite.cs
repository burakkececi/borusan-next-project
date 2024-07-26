using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Favorite
{
    public Guid AdvertId { get; set; }

    public int MyProperty { get; set; }
    public virtual ICollection<CustomerFavorite> CustomerFavorites { get; set; }
}
