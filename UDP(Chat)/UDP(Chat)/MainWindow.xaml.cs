using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UDP_Chat_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> messages = new ObservableCollection<string>();
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public MainWindow()
        {
            InitializeComponent();

            string Host = System.Net.Dns.GetHostName();
            string IP = System.Net.Dns.GetHostByName(Host).AddressList[0].ToString();
            server.Bind(new IPEndPoint(IPAddress.Parse(IP), 8888));
            
            Ip.Text = "192.168.1.217";
            Task.Run(() =>
            {
                while (true)
                {
                    byte[] arr1 = new byte[256];
                    EndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    int bytes = server.ReceiveFrom(arr1, ref sender);
                    
                    string message1 = DateTime.Now.ToShortTimeString()+ "   " + Encoding.Unicode.GetString(arr1, 0, bytes);                 
                    this.Dispatcher.Invoke(() =>
                    {
                        messages.Add(message1);
                    });                                                   
                }
            });
            ListBox.ItemsSource = messages;
            _scrollViewer.ScrollToEnd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Textbox.Text == "") { return; }
            string message = Textbox.Text + "\n" + "         Maks";
            string IP = Ip.Text;
            byte[] arr = Encoding.Unicode.GetBytes(message);

            client.SendTo(arr, new IPEndPoint(IPAddress.Parse(IP), 8888));

            string tmp = DateTime.Now.ToShortTimeString() + "   " + message;

            messages.Add(tmp);
            Textbox.Text = "";
        }
    }
}
