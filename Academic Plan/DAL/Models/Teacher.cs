using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Teacher
    {
        public int ID { get; set; }

        public string Surname { get; set; }

        virtual public List<Course> Course { get; set; }
    }
}
