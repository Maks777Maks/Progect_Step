using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BookShopStorage
{
    public class Book
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
        public int DateOfPublish { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public Book()
        {

        }
        public override string ToString()
        {
            return $"=============================\nName: {Name}\nTheme: {Theme}\nAuthor: {Author}\nPrice: {Price}\nPages: {Pages}\nDateOfPublish: {DateOfPublish}\nQuantity: {Quantity}\nImage: {Image}\n=============================\n";
        }
    }
}
