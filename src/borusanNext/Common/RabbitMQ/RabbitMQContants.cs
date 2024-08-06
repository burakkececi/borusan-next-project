using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RabbitMQ;
public class RabbitMQConstants
{
    public const string RabbitMQHost = "localhost";
    public const string DefaultExchangeType = "direct";

    public const string UserExchangeName = "UserExchange";
    public const string UserRegisterVerificationQueueName = "UserRegisterVerificationQueue";
    public const string UserRegisterAuthenticatorCodeQueueName = "UserRegisterAuthenticatorCodeQueue";


}
