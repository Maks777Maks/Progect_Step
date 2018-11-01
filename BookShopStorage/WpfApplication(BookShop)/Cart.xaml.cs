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
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : MetroWindow
    {
        BookRepos db = new BookRepos();
        ObservableCollection<Book> books = new ObservableCollection<Book>();
        double total;

        public Cart(ObservableCollection<Book> book)
        {
            InitializeComponent();
            books = book;
            gridProducts.ItemsSource = books;
            foreach(var i in books)
            {
                total += i.Price;
            }
            Total.Text = total.ToString();
            
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            books.Remove(gridProducts.SelectedItem as Book);
            gridProducts.ItemsSource = books;
            total = 0;
            foreach (var i in books)
            {
                total += i.Price;
            }
            Total.Text = total.ToString();
        }

        private void By(object sender, RoutedEventArgs e)
        {
            foreach(var i in books)
            {
                db.AddSale(i);
            }
            books.Clear();
            this.DialogResult = true;
            this.Close();       
        }
    }
}
