using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class Heading
    {
        public int ID { get; set; }
        public string Name_UA { get; set; }
        public string Name_RUS { get; set; }
        public string Name_EN { get; set; }

        virtual public List<Ads> _ads { get; set; }
    }
}
