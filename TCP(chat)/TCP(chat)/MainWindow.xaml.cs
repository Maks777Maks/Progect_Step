using MahApps.Metro.Controls;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
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
using TCPMessage;

namespace TCP_chat_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        TcpClient client = new TcpClient(new IPEndPoint(IPAddress.Parse("192.168.1.39"), 8888));
        ObservableCollection<Message> list = new ObservableCollection<Message>();
        ObservableCollection<string> list1 = new ObservableCollection<string>();

        public string ReadMessage()
        {
            NetworkStream str = client.GetStream();
            byte[] arr = new byte[256];
            int bytes = str.Read(arr, 0, 256);
            return Encoding.Unicode.GetString(arr, 0, bytes);
        }

        public MainWindow()
        {
            InitializeComponent();
            
            Autorization autoriz = new Autorization();
            autoriz.ShowDialog();
            if (autoriz.flag == true)
            {
                try
                {
                    client.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.41"), 8888));
                    var s = client.GetStream();
                    //Message m = new Message() { Color = "red", Date = "now", Sender = "$Maks$", Text = "Hello" };

                    //byte[] arr = BinarySerial.Serialize(m);
                    ////byte[] bb = Encoding.Unicode.GetBytes("$Maks$ &red");
                    //s.Write(arr, 0, arr.Length);
                    Task.Run(() =>
                    {
                        //while (true)
                        //{
                        //    byte[] b = Encoding.Unicode.GetBytes("#list#");

                        //    s.Write(b, 0, b.Length);
                        //    Thread.Sleep(5000);
                        //}
                    });
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            //byte[] bytes = new byte[2056];
                            //int Bytes = s.Read(bytes, 0, 2056);
                            //string message = Encoding.Unicode.GetString(bytes, 0, Bytes);
                            //if (message.StartsWith("&"))
                            //{

                            Message m = new Message();
                            string mes = ReadMessage();

                            var spl = mes.Split('|');

                            m.Sender = spl[0];
                            m.Text = spl[1];
                            m.Color = spl[2];
                            m.Date = spl[3];


                            //NetworkStream str = client.GetStream();
                            //byte[] arr = new byte[1024];
                            //int bytes = str.Read(arr, 0, 256);
                            //this.Dispatcher.Invoke(() =>
                            //    {
                            //        list1.Clear();
                            //    });

                            //    string[] words = message.Split(new char[] { ',' });
                            //    foreach (string i in words)
                            //    {
                            //        this.Dispatcher.Invoke(() =>
                            //        {
                            //            list1.Add(i);
                            //        });
                            //    }
                            //}
                            //else
                            //{
                                this.Dispatcher.Invoke(() =>
                                {
                                    list.Add(m);
                                    _scrollViewer.ScrollToEnd();
                                    _scrollViewer1.ScrollToEnd();
                                });
                            //}
                        }
                        
                    });
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ListBox.ItemsSource = list;
            ListBox1.ItemsSource = list1;          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = client.GetStream();
            Message m = new Message() { Color = "yellow", Date = DateTime.Now.ToShortTimeString(), Sender = "$Maks$", Text = textbox.Text };
            string str = m.Sender + "|" + m.Text + "|" + m.Color + "|" + m.Date;
            byte[] b = Encoding.Unicode.GetBytes(str);
            s.Write(b, 0, b.Length);
            textbox.Text = "";
            _scrollViewer.ScrollToEnd();
            _scrollViewer1.ScrollToEnd();
        }
    }
}

