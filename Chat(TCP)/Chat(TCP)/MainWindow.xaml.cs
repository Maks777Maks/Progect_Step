using MahApps.Metro.Controls;
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

namespace Chat_TCP_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        TcpClient client = new TcpClient(new IPEndPoint(IPAddress.Parse("192.168.1.39"), 8888));
        ObservableCollection<string> list = new ObservableCollection<string>(); 

        public MainWindow()
        {
            InitializeComponent();
            Autorization autoriz = new Autorization();
            autoriz.ShowDialog();
            if (autoriz.flag == true)
            {
                client.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.41"), 8888));
                var s = client.GetStream();
                Task.Run(() =>
                {
                    while (true)
                    {
                        byte[] bytes = new byte[256];
                        int Bytes = s.Read(bytes, 0, 256);
                        string message = Encoding.Unicode.GetString(bytes, 0, Bytes);
                        this.Dispatcher.Invoke(() =>
                        {
                            list.Add(message);
                        });
                    }
                });
            }
            ListBox.ItemsSource = list;
            _scrollViewer.ScrollToEnd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = client.GetStream();           
            byte[] b= Encoding.Unicode.GetBytes(textbox.Text);
            s.Write(b,0,b.Length);
        }
    }
}
