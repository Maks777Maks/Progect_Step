using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courswork_C_sharp_
{
    class Product
    {

        string _name_Product;
        string _mark;
        string _model;
        double _price_dollar;
        string _color;
        int _quantity;
        string _character_name;
        string _character_data;

        public Product()
        {
            _name_Product = "none";
            _mark = "none";
            _model = "none";
            _price_dollar = 0;
            _color = "none";
            _quantity = 0;
            _character_name = "none";
            _character_data = "none";
        }

        public Product(string a, string b, string c, double d, string e, int f, string g, string h)
        {
            _name_Product = a;
            _mark = b;
            _model = c;
            _price_dollar = d;
            _color = e;
            _quantity = f;
            _character_name = g;
            _character_data = h;
        }

        public string Name_Product
        {
            set { _name_Product = value; }
            get { return _name_Product; }
        }

        public string Mark
        {
            set { _mark = value; }
            get { return _mark; }
        }

        public string Model
        {
            set { _model = value; }
            get { return _model; }
        }


        public double Price_dollar
        {
            set { _price_dollar = value; }
            get { return _price_dollar; }
        }

        public string Color
        {
            set { _color = value; }
            get { return _color; }
        }

        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }

        public string Character_name
        {
            set { _character_name = value; }
            get { return _character_name; }
        }

        public string Character_data
        {
            set { _character_data = value; }
            get { return _character_data; }
        }
        //static void Add_Product(vector<Product> &a);
        //static void Delete_Product(vector<Product> &a);
        //static void Change_Price(vector<Product> &a);
        //static void Change_Quantity(vector<Product> &a);

        //static void Search_Product_By_Name(vector<Product> &a);
        //static void Search_Product_By_Mark(vector<Product> &a);
        //static void Search_Product_By_Price(vector<Product> &a);
        //static void Search_Product_By_Quantity(vector<Product> &a);

        //static void Sort_Product_By_Name(vector<Product> &a);
        //static void Sort_Product_By_Mark(vector<Product> &a);
        //static void Sort_Product_By_Price(vector<Product> &a);
        //static void Sort_Product_By_Quantity(vector<Product> &a);

        //static void Show_Product(vector<Product> &a);
        //void Print_Product();
        //static vector<Product> Read_File_Product(vector<Product> &a);
    };
}
