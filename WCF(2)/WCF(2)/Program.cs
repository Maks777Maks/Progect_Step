using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DiscInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(GetInfo));
            var b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.None;
            host.AddServiceEndpoint(typeof(IGetInfo), b, "net.tcp://192.168.1.39:8000/GetInfo");
            host.Open();
            Console.WriteLine("Process...");
            Console.WriteLine("Press Key for close");
            Console.ReadKey();
        }
    }
}
