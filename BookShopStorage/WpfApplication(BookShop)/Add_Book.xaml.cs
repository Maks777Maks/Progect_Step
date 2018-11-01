using BookShopStorage;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Add_Book.xaml
    /// </summary>
    public partial class Add_Book : MetroWindow
    {
        ObservableCollection<string> _genre = new ObservableCollection<string>();
        BookRepos db = new BookRepos();

        public Add_Book()
        {
            InitializeComponent();
            _genre = db.Get_Genre();
            Genre.ItemsSource = _genre;
            Genre.SelectedIndex = 0;
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
