using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class User
    {
        public int ID { get; set; }
        public string _login { get; set; }
        public string _password { get; set; }
        public string _name { get; set; }
        public string _tel { get; set; }
        public string _mail { get; set; }

        public City _city { get; set; }

        virtual public List<Ads> _ads { get; set; }
    }       
}
