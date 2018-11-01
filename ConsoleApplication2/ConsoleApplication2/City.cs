using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        virtual public List<Person> Persons { get; set; }
    }
}
