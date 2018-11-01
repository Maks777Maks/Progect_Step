using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1 db = new Model1();
            //Person p = new Person();
            //p.Name = "Oleg";
            //p.IDCity = 1;
            //db.Persons.Add(p);
            //City city = new City();
            //city.Name = "Kiev";
            //db.Cityes.Add(city);
            //db.SaveChanges();
            var list = db.Persons.Select(x => new
            {
                Name = x.Name,
                _City = db.Cityes.FirstOrDefault(c => c.ID == x.IDCity).Name
            });
            foreach (var i in list)
            {
                Console.WriteLine(i.Name);
                Console.WriteLine(i._City);
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}
<!---->