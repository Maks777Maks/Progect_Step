using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MyCalc));
            host.AddServiceEndpoint(typeof(IMyCalc), new BasicHttpBinding(), "http://localhost/MyCalc");
            host.Open();
            Console.WriteLine("Process...");
            Console.WriteLine("Press Key for close");
            Console.ReadKey();
        }
    }
}
