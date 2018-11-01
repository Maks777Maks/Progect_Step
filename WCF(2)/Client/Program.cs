using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = null;
           // var b = new NetTcpBinding();
           // b.Security.Mode = SecurityMode.None;
            ChannelFactory<IGetInfo> factory = new ChannelFactory<IGetInfo>(new BasicHttpBinding(), new EndpointAddress("http://192.168.1.39:8733/Design_Time_Addresses/GetInfo"));
            IGetInfo proxy = factory.CreateChannel();
            Console.WriteLine("Enter path:");
            path = Console.ReadLine();
            Console.WriteLine($"Content for path: {path}");
            foreach (var i in proxy.GetDiskInfo(path))
            {
                Console.WriteLine(i.ToString());
            }



        }
    }
}
