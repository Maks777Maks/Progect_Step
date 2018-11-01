using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class Moto_Brand
    {
        public int ID { get; set; }
        public string Brand { get; set; }

        virtual public List<Moto_Model> _Moto_Model { get; set; }

        
    }
}
