using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }

    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
            {
                new Department() { Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department() { Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department() { Id = 3, Country = "France", City = "Paris" },
                new Department() { Id = 4, Country = "Russia", City = "Moscow" }
            };

            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 24, DepId = 2 },
                new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 }
            };

            Console.WriteLine(" Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке :");
            Console.WriteLine("--------------------------------------------");
            var list = employees.Where(x => x.DepId == 2).Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName
            }); 
            foreach (var i in list)
            {
                Console.WriteLine(i.FirstName);
                Console.WriteLine(i.LastName);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("============================================");
            Console.WriteLine("Вывести список стран без повторений :");
            Console.WriteLine("--------------------------------------------");
            foreach (var i in departments.GroupBy(x => x.Country))
            {
                Console.WriteLine(i.Key);                
            }
            Console.WriteLine("============================================");
            Console.WriteLine("Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет :");
            Console.WriteLine("--------------------------------------------");
            var tmp1 = employees.Where(x => x.Age > 25).Take(3);
            foreach (var i in employees.Where(x => x.Age > 25).Take(3))
            {
                Console.WriteLine(i.FirstName);
                Console.WriteLine(i.LastName);
                Console.WriteLine(i.Age);
                Console.WriteLine("--------------------------------------------");
            }
            Console.WriteLine("============================================");
            Console.WriteLine("Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года :");
            Console.WriteLine("--------------------------------------------");
            var tmp2 = employees.Where(x => x.Age > 23 && x.DepId==2).Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age=x.Age
            });
            foreach (var i in tmp2)
            {
                Console.WriteLine(i.FirstName);
                Console.WriteLine(i.LastName);
                Console.WriteLine(i.Age);
                Console.WriteLine("--------------------------------------------");
            }
            Console.WriteLine("============================================");
        }
    }
}
