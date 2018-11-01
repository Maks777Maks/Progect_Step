using BookShopStorage;
using MahApps.Metro.Controls;
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

namespace WpfApplication_BookShop_
{
    /// <summary>
    /// Логика взаимодействия для Book.xaml
    /// </summary>
    public partial class Books : MetroWindow
    {

        public Book bOOk;
        public Books(Book b)
        {
            InitializeComponent();
            bOOk = b;
            grid.DataContext = bOOk;
        }

        private void Add_Cart(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
