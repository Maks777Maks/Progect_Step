using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courswork_C_sharp_
{
    class Order
    {
        int _code;
        string _data;
        Product _product;
        Client _client;

        public Order()
        {
            _code = 0;
            _data = "none";
            _product = new Product();
            _client = new Client();
        }

        public Order(int a, string b)
        {
            _code = a;
            _data = b;
            _product = new Product();
            _client = new Client();
        }

        public int Code
        {
            set { _code = value; }
            get { return _code; }
        }

        public string Data
        {
            set { _data = value; }
            get { return _data; }
        }

        //void Print_Order(int a);
        //static void Add_Order(vector<Order> &a, vector<Product>& p, vector<Client>& c);
        //static void Delete_Order(vector<Order> &a, vector<Product>& b);

        //static void Show_Order(vector<Order> &a, double rate);
        //static void Search_Order_By_Code(vector<Order> &a, double rate);
        //static void Search_Order_By_Surname(vector<Order> &a, double rate);
        //static void Search_Order_By_Data(vector<Order> &a, double rate);

        //static vector<Order> Read_File_Order(vector<Order> &a);
    };
}
