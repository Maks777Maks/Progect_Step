using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            s.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.18"), 1488));

            Console.WriteLine("Waiting...");

            while (true)
            {
                byte[] arr = new byte[256];
                EndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                int bytes = s.ReceiveFrom(arr, ref sender);

                string message = Encoding.Unicode.GetString(arr, 0, bytes);

                Console.WriteLine($"{sender.ToString()}: {message}");
            }

        }
    } 
}
