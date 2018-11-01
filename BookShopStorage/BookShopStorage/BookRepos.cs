using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopStorage
{
    public class BookRepos
    {
        
        private static string connectionString = "Data Source=USER-PC;" +
            "Initial Catalog= BookShop;" +
            "Integrated Security = true;";
        private static SqlConnection connection = new SqlConnection();

        public BookRepos()
        {
           connection = new SqlConnection(connectionString);
        }

        public ObservableCollection<Book> GetBooksByPred(Predicate<Book> predicate)
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            connection.Open();
            string cmd = "select Books.NameBook,Themes.NameTheme,Authors.FistName + ' ' + Authors.LastName as 'Author',Books.Price,Books.Date_OF_Publish,Books.Pages,Books.Quantity, Books.Drawing_Of_Book from Books inner join Authors on Authors.ID_Author = Books.ID_Author inner join Themes on Themes.ID_Theme = Books.ID_Theme";
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Book b = new Book();

                b.Name = Convert.ToString(reader["NameBook"]);
                b.Theme = Convert.ToString(reader["NameTheme"]);
                b.Author = Convert.ToString(reader["Author"]);
                b.Price = Convert.ToDouble(reader["Price"]);
                b.DateOfPublish = Convert.ToInt32(reader["Date_OF_Publish"]);
                b.Pages = Convert.ToInt32(reader["Pages"]);
                b.Quantity = Convert.ToInt32(reader["Quantity"]);
                b.Image = @"C:\Users\User\Desktop\Обложки книг\" + Convert.ToString(reader["NameBook"]) + ".jpg";
                if (predicate(b))
                {
                    books.Add(b);
                }
            }

            reader.Close();
            connection.Close();

            return books;
        }

        public ObservableCollection<Book> GetListbook()
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

        connection.Open();
        string cmd = "select Books.NameBook,Themes.NameTheme,Authors.FistName + ' ' + Authors.LastName as 'Author',Books.Price,Books.Date_OF_Publish,Books.Pages,Books.Quantity, Books.Drawing_Of_Book from Books inner join Authors on Authors.ID_Author = Books.ID_Author inner join Themes on Themes.ID_Theme = Books.ID_Theme";
        SqlCommand command = new SqlCommand(cmd, connection);
        SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Book b = new Book();
     
                b.Name = Convert.ToString(reader["NameBook"]);
                b.Theme = Convert.ToString(reader["NameTheme"]);
                b.Author = Convert.ToString(reader["Author"]);
                b.Price = Convert.ToDouble(reader["Price"]);
                b.DateOfPublish = Convert.ToInt32(reader["Date_OF_Publish"]);
                b.Pages = Convert.ToInt32(reader["Pages"]);
                b.Quantity = Convert.ToInt32(reader["Quantity"]);
                b.Image = @"C:\Users\User\Desktop\Обложки книг\" + Convert.ToString(reader["NameBook"]) + ".jpg";
                books.Add(b);
            }
            reader.Close();
            connection.Close();

            return books;
        }

        public bool AddSale(Book  tmp)
        {
            string cmd = $"insert into Sales values ((select Books.ID_Book from Books where Books.NameBook = '{tmp.Name}'),'{DateTime.Now.ToString("yyyy-MM-dd")}','{tmp.Price}','{1}',(select Shops.ID_Shop from Shops where Shops.NameShop = 'Ukrainians_BookShop'))";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            //command.ExecuteNonQuery();
            
            if (command.ExecuteNonQuery()>0) { connection.Close(); return true; }
            else { connection.Close(); return false; }
            
        }

        public ObservableCollection<string> Get_Genre()
        {
            ObservableCollection<string> _genre = new ObservableCollection<string>();
            connection.Open();
            string cmd = "Select Themes.NameTheme from Themes";
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();

            _genre.Add("All");
            while (reader.Read())
            {
                string tmp = Convert.ToString(reader["NameTheme"]);
                _genre.Add(tmp);
            }
            reader.Close();
            connection.Close();
            return _genre;
        }

        public ObservableCollection<string> Get_Author()
        {
            ObservableCollection<string> _authors = new ObservableCollection<string>();
            connection.Open();
            string cmd = "Select Authors.FistName + ' ' + Authors.LastName as 'Authors' from Authors";
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();

            _authors.Add("All");
            while (reader.Read())
            {
                string tmp = Convert.ToString(reader["Authors"]);
                _authors.Add(tmp);
            }
            reader.Close();
            connection.Close();
            return _authors;
        }
    }
}
