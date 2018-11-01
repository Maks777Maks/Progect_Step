using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Tic_tac_toe_UDP_
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public string IP { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
