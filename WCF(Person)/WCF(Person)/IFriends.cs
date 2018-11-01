using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Person_
{    
    [ServiceContract]
    public interface IFriends
    {
        [OperationContract]
        List<Person> GetFriends(Person p);
        
    }
    
}
