using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_1_
{
    [ServiceContract]
    public interface IMyCalc
    {
        [OperationContract]
        int Add(int a, int b);
    }
}
