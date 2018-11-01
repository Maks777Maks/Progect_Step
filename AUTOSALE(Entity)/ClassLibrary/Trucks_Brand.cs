using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Trucks_Brand
    {
        public int ID { get; set; }
        public string Brand { get; set; }

        virtual public List<Trucs_Model> _Trucs_Model { get; set; }
        
    }
}
