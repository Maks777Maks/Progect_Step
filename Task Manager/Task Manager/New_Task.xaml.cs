using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task_Manager
{
    /// <summary>
    /// Логика взаимодействия для New_Task.xaml
    /// </summary>
    public partial class New_Task : MetroWindow
    {
        public New_Task()
        {
            InitializeComponent();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            if(Textbox1.Text=="")
            {
                Process.Start(Textbox.Text);
            }
            else
            {
                Process.Start(Textbox.Text, Textbox1.Text);
            }
            
            Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void IP(object sender, RoutedEventArgs e)
        {
            string Host = System.Net.Dns.GetHostName();
            string IP = System.Net.Dns.GetHostByName(Host).AddressList[0].ToString();
            MessageBox.Show(IP);
        }
    }
}
