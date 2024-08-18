using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models;
public class InboxEvent
{
    public long Id { get; protected set; }
    public Guid EventId { get; set; }
    public bool Processed { get; set; }
}
