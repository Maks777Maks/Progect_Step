using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wcf_Duplex_
{    
    public interface ICallBack
    {
        [OperationContract(IsOneWay =true)]
        void CallBack(string mes);
    }
}
