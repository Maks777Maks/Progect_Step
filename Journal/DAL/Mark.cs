using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [DataContract(IsReference =true)]
    public class Mark
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int mark { get; set; }
        [DataMember]
        public Student student { get; set; }
        [DataMember]
        public Subject subject { get; set; }

        
    }
}
