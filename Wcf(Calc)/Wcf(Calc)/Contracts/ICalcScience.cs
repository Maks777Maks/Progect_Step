using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wcf_Calc_.Contracts
{
    [ServiceContract]
    public interface ICalcScience
    {
        [OperationContract]
        double[] Discriminant(double a, double b, double c);
    }
}
