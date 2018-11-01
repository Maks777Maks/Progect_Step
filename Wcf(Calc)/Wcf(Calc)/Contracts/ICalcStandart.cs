using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_Calc_
{    
    [ServiceContract]
    public interface ICalcStandart
    {
        [OperationContract]
        double GetPlus(double a, double b);
        [OperationContract]
        double GetMinus(double a, double b);
        [OperationContract]
        double GetMulti(double a, double b);
        [OperationContract]
        double GetDivision(double a, double b);
    }
    
}
