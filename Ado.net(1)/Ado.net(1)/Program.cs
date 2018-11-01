using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_1_
{
    class Program
    {
        
        private static string connectionString = "Data Source=USER-PC;" +
            "Initial Catalog=BookShop;" +
            "Integrated Security = true;";
        private static SqlConnection connection = new SqlConnection(connectionString);                            
      
        private static void Add_Book(string name, int id_theme, int id_author, double price, string image, string date, int page, int quant)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand($"Insert into Books values('{name}',{id_theme},{id_author},{price},null,{date},{page},{quant})", connection);
            Console.WriteLine(cmd.CommandText);
            int res = cmd.ExecuteNonQuery();
            Console.WriteLine($"Book {name} added");
            connection.Close();
        }

        static void Main(string[] args)
        {
            
            Add_Book("War",1,16,55,null,"2017",555,222);
            Console.ReadLine();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString =
            //"Data Source=USER-PC;" +
            //"Initial Catalog=BookShop;" +
            //"Integrated Security = true;";

            //connection.Open();


            //SqlCommand cmd = new SqlCommand("Insert into Countries values('Poland')", connection);
            //int c = cmd.ExecuteNonQuery();

            //SqlCommand cmd1 = new SqlCommand("Select SUM(Sales.Quantity) from Sales", connection);
            //object result = cmd1.ExecuteScalar();
            //Console.WriteLine($"result: { result.ToString()}");

            ////SqlCommand cmd2 = new SqlCommand("Select * from Books", connection);
            ////SqlDataReader reader = cmd2.ExecuteReader();

            ////for (int i = 0; i < reader.FieldCount; i++)
            ////{
            ////    Console.Write($"{reader.GetName(i)}     ");
            ////}
            ////Console.WriteLine();
            ////Console.WriteLine();
            ////while (reader.Read())
            ////{
            ////    for (int i = 0; i < reader.FieldCount; i++)
            ////    {
            ////        Console.Write($"{reader.GetValue(i)}     ");
            ////    }
            ////    Console.WriteLine();
            ////}


            SqlCommand cmd2 = new SqlCommand("Select Shops.NameShop, Case Countries.Name "+
                "When 'Ukraine' Then 'UA' " +
                "When 'Russia' Then 'RUS' " +
                "When 'Canada' Then 'CAN' " +
                "When 'Poland' Then 'PL' " +
                "When 'Denmark' Then 'DM' " +
                "When 'England' Then 'UK' " +
                "else Countries.Name End " +
                "as 'Countries' " +
                "from Shops " +
                "inner join Countries on Countries.ID_Country = Shops.ID_Country", connection);
            Console.WriteLine(cmd2.CommandText.ToString());
            SqlDataReader reader = cmd2.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i)}     ");
            }
            Console.WriteLine();
            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetValue(i)}     ");
                }
                Console.WriteLine();
            }

            //Console.WriteLine("[1] - Select Countries");
            //Console.WriteLine("[2] - Select Books");
            //Console.WriteLine("[3] - Select Shops");
            //Console.WriteLine("[4] - Select Authors");
            //Console.WriteLine("[5] - Select Themes");


            //SqlCommand cmd2 = new SqlCommand();
            //while (true)
            //{
            //    string sw = Console.ReadLine();
            //    switch (sw)
            //    {
            //        case "1":
            //            cmd2 = new SqlCommand("Select * from Countries", connection);
            //            break;
            //        case "2":
            //            cmd2 = new SqlCommand("Select * from Books", connection);
            //            break;
            //        case "3":
            //            cmd2 = new SqlCommand("Select * from Shops", connection);
            //            break;
            //        case "4":
            //            cmd2 = new SqlCommand("Select * from Authors", connection);
            //            break;
            //        case "5":
            //            cmd2 = new SqlCommand("Select * from Themes", connection);
            //            break;
            //    }

            //    SqlDataReader reader = cmd2.ExecuteReader();
            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        Console.Write($"{reader.GetName(i)}     ");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    while (reader.Read())
            //    {
            //        for (int i = 0; i < reader.FieldCount; i++)
            //        {
            //            Console.Write($"{reader.GetValue(i)}     ");
            //        }
            //        Console.WriteLine();
            //    }
            //    reader.Close();
            //}
        }
    }
}
