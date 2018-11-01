using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
   
    [ServiceContract]
    public interface ISubject
    {
        [OperationContract]
        void AddSubject(Subject subject);

        [OperationContract]
        List<Subject> GetSubject();       
    }    
}
