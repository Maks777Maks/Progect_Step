using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopStorage;
using System.Configuration;

namespace ConsoleApplication_BookShop_
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepos db = new BookRepos();
            List<Book> books = db.GetListbook();

            foreach (Book b in books)
            {
                Console.WriteLine(b.ToString());
            }

            Sale sale = new Sale(books[0]);
           bool flag= db.AddSale(books[0]);
            if(flag==true)
            {
                Console.WriteLine("The addition of the sale was completed successfully");
            }
            else
            {
                Console.WriteLine("Error!!!");
            }
        }
    }
}
