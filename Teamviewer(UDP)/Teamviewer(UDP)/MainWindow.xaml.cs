using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Windows.Interop;
using Library_Streamer;

namespace Teamviewer_UDP_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : MetroWindow
    {
        public void ReciveImage()
        {
            var my_address = new IPEndPoint(IPAddress.Parse("192.168.1.39"), 8000);
            UdpClient client = new UdpClient(my_address);
            //var receiver_address = new IPEndPoint(IPAddress.Parse("192.168.1.41"), 8000);
            IPEndPoint sender = new IPEndPoint(IPAddress.Parse("192.168.1.41"), 8000);
            while(true)
            {
                try
                {
                    byte[] s= client.Receive(ref sender);
                    //int size = Convert.ToInt32(Encoding.Unicode.GetString(s, 0, s.Length));
                    //byte[] bytes = new byte[60000 * size];

                    //for (int i = 0; i < size; i++)
                    //{
                    //    byte[] tmparr = client.Receive(ref sender);
                    //    bytes.Concat(tmparr);                       
                    //}

                    var b = BitmapFromByte(s);
                    this.Dispatcher.Invoke(() =>
                    {
                        IMAGE.Source = Imaging.CreateBitmapSourceFromHBitmap(
                        b.GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        
                    });
                }
                catch (Exception)
                {

                    throw;
                }
               

               
                //MessageBox.Show(bytes.Length.ToString());
               
            }
           
        }

        public Bitmap BitmapFromByte(byte[] tmp)
        {
            using (MemoryStream stream = new MemoryStream(tmp))
            {
                Bitmap b = new Bitmap(stream);
                return b;
            }             
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        public MainWindow()
        {

            InitializeComponent();
            var my_address = new IPEndPoint(IPAddress.Parse("192.168.1.39"), 8000);
            //UdpClient client = new UdpClient(my_address);

            //client.JoinMulticastGroup(IPAddress.Parse("240.1.1.1"));
            Streamer streamer = new Streamer(my_address);
            streamer.Client.JoinMulticastGroup(IPAddress.Parse("235.5.5.11"), 50);
            Task.Run(() =>
            {
                while(true)
                {
                    
                    Bitmap b = streamer.GetImage();
                    IntPtr ptr = b.GetHbitmap();
                   // MessageBox.Show("asd");
                    this.Dispatcher.Invoke(() =>
                    {
                        
                        IMAGE.Source = Imaging.CreateBitmapSourceFromHBitmap(
                        ptr,
                        IntPtr.Zero,
                        Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    });
                    DeleteObject(ptr);
                }
            });           
        }
    }
}
