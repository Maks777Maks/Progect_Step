using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Course
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual Teacher Teacher { get; set; }

        virtual public List<Student> Student { get; set; }

    }
}
