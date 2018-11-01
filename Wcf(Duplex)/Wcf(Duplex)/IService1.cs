using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_Duplex_
{
    
    [ServiceContract(CallbackContract =typeof(ICallBack))]
    public interface IService1
    {
        [OperationContract(IsOneWay=true)]
        void Subscribe(DateTime a);

    }   
}
