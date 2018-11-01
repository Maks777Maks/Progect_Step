using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace DiscInfo
{
    [ServiceContract]
    public interface IGetInfo
    {
        [OperationContract]
        string[] GetDiskInfo(string path);
    }
}
