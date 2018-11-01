using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>()
            { 
                new Person(){ Name = "Andrey", Age = 24, City = "Kyiv" },
                new Person(){ Name = "Liza", Age = 18, City = "Moscow" },
                new Person(){ Name = "Oleg", Age = 15, City = "London" },
                new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
                new Person(){ Name = "Sergey", Age = 32, City = "Kyiv" }
            };
            Console.WriteLine("Выбрать людей, старших 25 лет:");
            Console.WriteLine("--------------------------------------------");
            var linq = person.Where(x => x.Age > 25);
            foreach(var i in linq)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("============================================");
            Console.WriteLine("Выбрать людей, проживающих не в Киеве :");
            Console.WriteLine("--------------------------------------------");
            linq = person.Where(x => x.City != "Kyiv");
            foreach (var i in linq)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("============================================");
            Console.WriteLine(" Выбрать имена людей, проживающих в Киеве :");
            Console.WriteLine("--------------------------------------------");
            var linq1 = person.Where(x => x.City == "Kyiv").Select(x => x.Name);
            foreach (var i in linq1)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("============================================");
            Console.WriteLine(" Выбрать людей старших 35 лет с именем Sergey :");
            Console.WriteLine("--------------------------------------------");
            linq = person.Where(x => x.Name == "Sergey" && x.Age > 35);
            foreach (var i in linq)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("============================================");
            Console.WriteLine("  Выбрать людей, проживающих в Москве :");
            Console.WriteLine("--------------------------------------------");
            linq = person.Where(x => x.City == "Moscow");
            foreach (var i in linq)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("============================================");
        }
    }
}
