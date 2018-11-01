using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courswork_C_sharp_
{
    class Base
    {
        List<Product> _products;
        List<Client> _clients;
        List<Order> _orders;
        List<User> _users;
        
        Base()
        {
            _products = new List<Product>();
            _clients = new List<Client>();
            _orders = new List<Order>();
            _users = new List<User>();
        }

        void Write_to_File_Order()
        {

        }
        void Write_to_File_User()
        {

        }
        void Write_to_File_Product()
        {

        }
        void Write_to_File_Client()
        {

        }
        void Authorization()
        {
            Start:

            ConsoleKeyInfo key;
            string tmp_login;      //переменная в которую вводим логин
            string tmp_password = ""; //переменная в которую вводим пароль
            string tmp_Type;
            bool flag = false;

            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\t\tEnter Your Login:");
            tmp_login = Console.ReadLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\t\tEnter Your Password:");
            
            for (int i = 0; i < 10; i++)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                tmp_password += key.KeyChar;
                Console.Write("*");
            }
            
            foreach (var i in _users)
            {
                if (i.Login == tmp_login)
                {
                    if (i.Password == tmp_password)
                    {
                        Console.WriteLine($"\n\t\t\tWellcom\t\t  {i.Login}  \n ");
                        Console.ReadKey();
                        
                        if (i.Type == "Maneger")
                        {
                            Imenu* menu = new Menu_Maneger;
                            menu->Menu();
                        }
                        else if (i.Type == "Top Maneger")
                        {
                            Imenu* menu = new Menu_Top;
                            menu->Menu();
                        }
                        Console.ReadKey();
                        goto End;
                    }
                    else
                    {
                        Console.WriteLine("Your login or password is incorrect!!!  /n");
                        Console.ReadKey();
                        system("pause"); break;
                    }
                }
            }
            if (flag == false)
            {
                cout << "\n\n\a\t\t\tYour login or password is incorrect!!!\n\n";
                system("pause");
                goto Start;
            }
            End:
            cout << endl;
        }
    };
}
