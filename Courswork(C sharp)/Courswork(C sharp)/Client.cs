using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courswork_C_sharp_
{
    class Client
    {
        string _name;
        string _surname;
        string _tel;

        public Client()
        {
            _name = "none";
            _surname = "none";
            _tel = "none";
        }

        public Client(string a, string b, string c)
        {
            _name = a;
            _surname = b;
            _tel = c;
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Surname
        {
            set { _surname = value; }
            get { return _surname; }
        }

        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }

        //static void Add_Client(vector<Client> &a);
        //static void Change_Tel(vector<Client> &a);
        //static void Delete_Client(vector<Client> &a);
        //static void Search_Client_By_Surname(vector<Client> &a);
        //static void Search_Client_By_Tel(vector<Client> &a);
        //void Print_Client();
        //static void Show_Clients(vector<Client> &a);
        //static vector<Client> Read_File_Client(vector<Client> &a);

    };
}
