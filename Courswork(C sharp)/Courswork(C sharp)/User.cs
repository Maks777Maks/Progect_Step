using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courswork_C_sharp_
{
    class User
    {

        string _login;
        string _password;
        string _type;

        public User()
        {
            _login = "none";
            _password = "none";
            _type = "none";
        }

        public User(string a, string b, string c)
        {
            _login = a;
            _password = b;
            _type = c;
        }

        public string Login
        {
            set { _login = value; }
            get { return _login; }
        }

        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }

        //static void Add_User(vector<User> &a);
        //static void Delete_User(vector<User> &a);


        //static void Show_User(vector<User> &a);

        //static vector<User> Read_File_User(vector<User> &a);
    };
}
