using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration
{
    public class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string WorkPlace { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Model1 db = new Model1();
            Person p = new Person();
            p.Name = "Vasja";
            p.Age = 21;
            db.Persons.Add(p);
            p.WorkPlace = "Step";
            p.City = "Rivne";
            db.SaveChanges();
        }
    }
}
