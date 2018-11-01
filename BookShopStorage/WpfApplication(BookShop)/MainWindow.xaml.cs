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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookShopStorage;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;


namespace WpfApplication_BookShop_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        BookRepos db = new BookRepos();
        ObservableCollection<Book> books = new ObservableCollection<Book>();
        ObservableCollection<Book> books_in_cart = new ObservableCollection<Book>();
        ObservableCollection<string> _genre = new ObservableCollection<string>();
        ObservableCollection<string> _author = new ObservableCollection<string>();

        Book _book;
        public MainWindow()
        {
            InitializeComponent();

            books = db.GetListbook();
            view.ItemsSource = books;
            _genre = db.Get_Genre();          
            Genre.ItemsSource = _genre;
            Genre.SelectedIndex = 0;
            _author = db.Get_Author();
            Authors.ItemsSource = _author;
            Authors.SelectedIndex = 0;

        }

        private void view_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {           
            _book = (view.SelectedItem as Book);
            Books DI = new Books(_book);
            DI.ShowDialog();
            //if(DialogResult==true)
            //{
                books_in_cart.Add(DI.bOOk);
           // }        
        }

        private void Click_Cart(object sender, RoutedEventArgs e)
        {
            Cart _cart = new Cart(books_in_cart);
            if (_cart.ShowDialog() == true)
            {
                if (DialogResult == true)
                {
                    books = db.GetListbook();
                    view.ItemsSource = books;
                }
            }
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            if (Genre.ItemsSource == null || Authors.ItemsSource == null) { return; }
            books = db.GetListbook();
            ObservableCollection<Book> Tmp = new ObservableCollection<Book>();
            if (Genre.SelectedIndex == 0 && Authors.SelectedIndex == 0)
            {
                view.ItemsSource = books;
            }
            else if (Genre.SelectedIndex != 0 && Authors.SelectedIndex == 0)
            {
                foreach (Book b in books)
                {
                    if (b.Theme == Genre.SelectedItem.ToString())
                    {
                        Tmp.Add(b);
                    }
                }
                books = Tmp;
                view.ItemsSource = books;
            }
            else if (Authors.SelectedIndex != 0 && Genre.SelectedIndex == 0)
            {
                foreach (Book b in books)
                {
                    if (b.Author == Authors.SelectedItem.ToString())
                    {
                        Tmp.Add(b);
                    }
                }
                books = Tmp;
                view.ItemsSource = books;
            }
            else
            {
                foreach (Book b in books)
                {
                    if (b.Author == Authors.SelectedItem.ToString() && b.Theme == Genre.SelectedItem.ToString())
                    {
                        Tmp.Add(b);
                    }
                }
                books = Tmp;
                view.ItemsSource = books;
            }
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            Add_Book add_Book = new Add_Book();
            if (add_Book.ShowDialog() == true)
            {
                
            }
        }
    }
}
