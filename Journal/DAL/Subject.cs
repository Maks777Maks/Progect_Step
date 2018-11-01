using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [DataContract(IsReference = true)]
    public class Subject
    {
        public Subject()
        {
           
            marks = new List<Mark>();
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime time { get; set; }

        [DataMember]
        public List<Mark> marks { get; set; }
    }
}
