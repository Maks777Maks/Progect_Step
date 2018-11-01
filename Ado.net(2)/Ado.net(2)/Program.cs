using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_2_
{
    class Program
    {
        private static SqlConnection connection = new SqlConnection();
        private static string connectionString;
        private static SqlCommand cmd = new SqlCommand();
        private static List<string> databases = new List<string>();
        private static List<string> tables = new List<string>();
        private static SqlDataReader reader;

        static public void DataBase()
        {
            cmd = new SqlCommand("Select Name from sys.databases", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                databases.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            for (int i = 0; i < databases.Count; i++)
            {
                Console.WriteLine($"[{i+1}] -  for {databases[i]}");
            }
            Console.WriteLine("[0] -  for Exit");
        }

        static public void Tables(int index)
        {
            cmd = new SqlCommand($"use {databases[index]}; Select Name from sys.tables", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tables.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            for (int i = 0; i < tables.Count; i++)
            {
                Console.WriteLine($"[{i+1}] -  for {tables[i]}");
            }
            Console.WriteLine("[0] -  for Exit");
            Console.WriteLine("[99] -  for Return");
        }

        static public void FromTables(int based, int tab)
        {
            cmd = new SqlCommand($"use {databases[based]}; Select * from {tables[tab]}", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetValue(i)}     ");
                }
                Console.WriteLine();
            }
            reader.Close();
            Console.ReadKey();
        }

        static public string Connection()
        {
            string servername;
            string catalog;
            string Login;
            string password;
            char ch;
            Console.WriteLine("Enter server name:");
            servername = Console.ReadLine();
            Console.WriteLine("Enter catalog name:");
            catalog = Console.ReadLine();
            Console.WriteLine("You have Login?:");
            ch = Convert.ToChar(Console.ReadLine());
            if (ch == 'y')
            {
                Console.WriteLine("Enter Login:");
                Login = Console.ReadLine();
                Console.WriteLine("Enter Password name:");
                password = Console.ReadLine();
                connectionString = $"Data Source={servername};" +
            $"Initial Catalog={catalog};" +
             $"User ID ={Login};" +
              $"Password={password};";                
            }
            else
            {
                connectionString = $"Data Source={servername};" +
            $"Initial Catalog={catalog};" +
            "Integrated Security = true;";              
            }
            return connectionString;
        }

        static void Main(string[] args)
        {
            try
            {
                connectionString = Connection();
                connection = new SqlConnection(connectionString);
                connection.Open();
                Start:
                while (true)
                {
                    Console.Clear();
                    DataBase();
                    Console.WriteLine("Enter digit: ");
                    int str = Convert.ToInt32(Console.ReadLine());
                    if (str == 0) goto Finish;
                    while (true)
                    {
                        Console.Clear();
                        Tables(str - 1);
                        Console.WriteLine("Enter digit: ");
                        int str1 = Convert.ToInt32(Console.ReadLine());
                        if (str1 == 0) goto Finish;
                        else if (str1 == 99) goto Start;
                        else
                        {
                            Console.Clear();
                            FromTables(str - 1, str1 - 1);
                        }
                        tables.Clear();
                    }
                }
                Finish:
                connection.Close();
            }
            catch(Exception e) { Console.WriteLine(e.Message); };
        }          
        }
    }

