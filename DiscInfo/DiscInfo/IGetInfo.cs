using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DiscInfo
{
    [ServiceContract]
    public interface IGetInfo
    {
        [OperationContract]
        string[] GetDiskInfo(string path);
    }
}
