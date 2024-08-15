using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Infrastructure.Events.User;
public class UserAuthenticatorCodeEvent
{
    public string UserEmailAdress { get; set; }
    public string AuthenticatorCode { get; set; }
}
