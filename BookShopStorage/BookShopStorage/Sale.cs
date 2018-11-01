using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopStorage
{
    public class Sale
    {
        
        public Book book { get; set; }
        public DateTime DateofPublish { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ShopName { get; set; }

        public Sale(Book _book)
        {
            book = _book;
            DateofPublish = DateTime.Now;
            Quantity = 1;
            Price = Quantity * book.Price;
            ShopName = "Ukrainians_BookShop";
        }
    }
}
