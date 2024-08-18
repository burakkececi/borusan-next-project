using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Events.User;
public class UserRegisterVerificationEvent : BaseEvent
{
    public string UserEmailAddress { get; set; }
    public string VerifyEmailUrlPrefix { get; set; }
    public string AddedEmailAuthenticatorActivationKey { get; set; }
}
