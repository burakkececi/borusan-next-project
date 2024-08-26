using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations;
public class RedisConfiguration
{
    public string Endpoint { get; set; }
    public string Password { get; set; }
    public bool UseSSL { get; set; }
}
