using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class TableParser
    {
        Type type;

        public TableParser(ITable t)
        {
            type = t.GetType();
        }

        public void ShowProperties()
        {
            Console.WriteLine(type.Name);
            Console.WriteLine("---------------------------------------------------------");
            foreach (var i in type.GetProperties())
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine("---------------------------------------------------------");
        }
        public void ShowTypes()
        {

            Console.WriteLine("---------------------------------------------------------");
            foreach (var i in type.GetProperties())
            {
                Console.WriteLine(i.PropertyType.Name);
            }
            Console.WriteLine("---------------------------------------------------------");
        }

        public string CreateTableQuery()
        {

            var tmp = type.GetProperties();

            string sqlsc;
            sqlsc = "CREATE TABLE " + type.Name + "s" + "(";
            for (int i = 0; i < tmp.Length; i++)
            {
                sqlsc += "\n [" + tmp[i].Name + "] ";
                string columnType = tmp[i].PropertyType.Name.ToString();

                switch (columnType)
                {
                    case "Int32":
                        sqlsc += " int ";
                        break;
                    case "Int64":
                        sqlsc += " bigint ";
                        break;
                    case "Int16":
                        sqlsc += " smallint";
                        break;
                    case "Byte":
                        sqlsc += " tinyint";
                        break;
                    case "Decimal":
                        sqlsc += " decimal ";
                        break;
                    case "DateTime":
                        sqlsc += " datetime ";
                        break;
                    case "String":
                        sqlsc += " nvarchar(MAX) ";
                        break;
                    case "Double":
                        sqlsc += " money ";
                        break;
                }
                if (tmp[i].Name == "ID")
                    sqlsc += " primary key identity ";
                else
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }

        public void CreateTable(string ConnString)
        {
            var createstr = CreateTableQuery();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnString;
            conn.Open();
            SqlCommand com = new SqlCommand(createstr, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }

        public string InsertInTableQuery(object o)
        {
            Type t = o.GetType();
            if (t != type)
            {
                Console.WriteLine("Eror");
                return null;
            }
            var tmp = type.GetProperties();
            var val = t.GetProperties();
                       
            string sqlsc;
            sqlsc = "Insert into " + t.Name + "s" + "(";
            for (int i = 1; i < tmp.Length; i++)
            {
                if (i == tmp.Length - 1)
                {                    
                    sqlsc += tmp[i].Name + " ";
                }
                else
                sqlsc += tmp[i].Name + ", ";
            }
            sqlsc += ") " + "values (";
            for (int i = 1; i < tmp.Length; i++)
            {              
                if (tmp[i].PropertyType.Name == "String")
                {
                    sqlsc += "'" + val[i].GetValue(o)+"'";

                }
                else
                {
                    sqlsc += val[i].GetValue(o);
                }
                    if (i != tmp.Length - 1)
                {
                    sqlsc += ",";
                }                    
                               
            }
            sqlsc += ")";
            return sqlsc.Substring(0, sqlsc.Length - 1) + ")";
        }

        public void InsertInTable(string ConnString,object o)
        {
            object obj = o;
            var createstr = InsertInTableQuery(obj);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnString;
            conn.Open();
            SqlCommand com = new SqlCommand(createstr, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}
