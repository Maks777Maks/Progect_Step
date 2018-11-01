using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class Ads
    {
        public int ID { get; set; }
        //public string _name { get; set; }        
        public string _text { get; set; }
        public string _miliage { get; set; } 
        public int _price { get; set; }
        public string _brand { get; set; }
        public string _model { get; set; }


        public Engine _engine { get; set; }

        public Transmission _transmission { get; set; }

        public Fuel _fuel { get; set; }

        public Year _year { get; set; }

        public Heading _heading { get; set; }

        public User _user { get; set; }

        virtual public List<Image> _image { get; set; }

        virtual public List<Characteristic> _characteristic { get; set; }
    }
}
