using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Events.CustomerFavorite;
public class UpdateCustomerFavoriteEvent : BaseEvent
{
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }
}
