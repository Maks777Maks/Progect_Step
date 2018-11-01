using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using WMPLib;

namespace Wcf_Duplex_
{
    
    public class Service1 : IService1
    {
        public void Subscribe(DateTime a)
        {
            ICallBack handler = OperationContext.Current.GetCallbackChannel<ICallBack>();
            while(true)
            {
                if (DateTime.Now.ToShortTimeString() == a.ToShortTimeString())
                {
                    handler.CallBack("LOX");
                    
                    break;
                }
            }
            
                
               
                     
        }
    }
}
