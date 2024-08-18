using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models;
public enum OutboxEventState
{
    ReadyToSend = 1,
    SendToQueue = 2,
    Completed = 3,
}
