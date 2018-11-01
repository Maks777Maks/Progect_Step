using Library;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflex
{
    class Program
    {
        static void Main(string[] args)
        {            
        string ConnectionString =
            "Data Source=USER-PC;" +
           "Initial Catalog= master;" +
           "Integrated Security = true;";

        //TableParser par = new TableParser(new Person());
        //    par.ShowProperties();          
        //    par.ShowTypes();
        //    Console.WriteLine(par.CreateTableQuery());
        //    par.CreateTable(ConnectionString);
        //    Console.WriteLine("-----------------------------------------------------------");
            TableParser par1 = new TableParser(new PC());
            //par1.ShowProperties();
            //par1.ShowTypes();
           // Console.WriteLine(par1.CreateTableQuery());
           // par1.CreateTable(ConnectionString);
            Console.WriteLine("-----------------------------------------------------------");
            PC pc = new PC { Mark = "ASUS", Model = "LDP 1234", Price = 24999 };
            PC pc1 = new PC { Mark = "ACER", Model = "ABC 1234", Price = 19800 };
            PC pc2 = new PC { Mark = "HP", Model = "zzz 1234", Price = 12340 };
            //Console.WriteLine(par1.InsertInTableQuery(pc));
            //par1.InsertInTable(ConnectionString,pc);
            par1.InsertInTable(ConnectionString, pc1);
            par1.InsertInTable(ConnectionString, pc2);
        }
    }
}
