using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class Car_Brand
    {
        public int ID { get; set; }
        public string Brand { get; set; }

        virtual public List<Car_Model> _Car_Model { get; set; }

        public override string ToString()
        {
            return Brand.ToString();
        }
    }
}
