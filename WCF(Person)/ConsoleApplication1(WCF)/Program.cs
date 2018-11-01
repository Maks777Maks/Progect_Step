using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1_WCF_.ServiceReference1;

namespace ConsoleApplication1_WCF_
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFriendsClient friends = new GetFriendsClient();
            
            foreach (var i in friends.GetPeople(new Person { Name = "Vasyan", Age = 33 }))
            {
                Console.WriteLine($"{i.Name}     {i.Age}");
            }
        }
    }
}
