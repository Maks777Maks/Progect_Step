using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Student
    {

        public Student()
        {
            Course = new List<Course>();
        }
        public int ID { get; set; }

        public string Surname { get; set; }

        public virtual List<Course> Course { get; set; }
    }
}
