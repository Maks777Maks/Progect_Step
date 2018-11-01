using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Library_Streamer
{
    public class Streamer
    {
        public UdpClient Client { get; set; }
        public IPEndPoint MyAddress { get; set; }

        public Streamer(IPEndPoint a)
        {
            MyAddress = a;
            Client = new UdpClient(8000);
        }



        public void SendImage(IPEndPoint receiver, Bitmap b)
        {
            var image = b;
            byte[] arr = NVConverter.BytesFromBitmap(image);

            Client.Send(arr, arr.Length, receiver);
        }

        //you need this
        public Bitmap GetImage()
        {
            IPEndPoint sender = null; //new IPEndPoint(IPAddress.Any, 0);
            byte[] arr = Client.Receive(ref sender);
            return NVConverter.BitmapFromBytes(arr);
        }

        public byte[] GetImageArr()
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            byte[] arr = Client.Receive(ref sender);
            return arr;
        }

    }
}
