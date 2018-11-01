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
            var b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.None;
            ChannelFactory<IMyCalc> factory = new ChannelFactory<IMyCalc>(b,new EndpointAddress("net.tcp://10.7.180.125:8000/MyCalc"));
            IMyCalc proxy = factory.CreateChannel();
            Console.WriteLine("start");
            try
            {
                Console.WriteLine(proxy.Add(5, 6));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("end");
        }
    }
}
