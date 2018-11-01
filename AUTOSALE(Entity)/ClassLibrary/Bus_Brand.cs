using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Bus_Brand
    {
        public int ID { get; set; }
        public string Brand { get; set; }

        virtual public List<Bus_Model> _Bus_Model { get; set; }

        public override string ToString()
        {
            return Brand.ToString();
        }
    }
}
