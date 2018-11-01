using MahApps.Metro.Controls;
using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
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

namespace SMTP_MAIL_
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    

    public partial class Authentication : MetroWindow
    {

        
        public string password = null;
        public string login = null;

        public Authentication()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login = LOGIN.Text;
            password = PASSWORD.Password;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
