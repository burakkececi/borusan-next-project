using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pricing.Constants;
public class PricingOperationClaims
{
    private const string _section = "Pricing";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
}
