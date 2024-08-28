using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models;
public class PricePredictionRequestModel
{
    public string brand { get; set; }
    public string model { get; set; }
    public string modelextension { get; set; }
    public double kilometers { get; set; }
    public int modelyear { get; set; }
}
