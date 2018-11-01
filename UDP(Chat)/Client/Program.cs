using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {       
            static void Main(string[] args)
        {
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //client.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 666));
                

                //Console.WriteLine("Waiting...");

                Task.Run(() =>
                {
                    while (true)
                    {
                        byte[] arr1 = new byte[256];
                        EndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                        int bytes = server.ReceiveFrom(arr1, ref sender);

                        string message1 = Encoding.Unicode.GetString(arr1, 0, bytes);

                        Console.WriteLine($"{sender.ToString()}: {message1}");
                    }
                });


                while (true)
                {
                    Console.WriteLine("Input Message:");
                    string message = Console.ReadLine();
                    byte[] arr = Encoding.Unicode.GetBytes(message);

                    client.SendTo(arr, new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1488));
                }
            }
        }   
}
