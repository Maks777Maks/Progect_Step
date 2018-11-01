using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Code_First_
{
    public class Message
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
       
       
        public int? IDPersonSender { get; set; }   
        public int? IDPersonGetter { get; set; }

        [ForeignKey("IDPersonSender")]
        virtual public Person PersonSender { get; set; }
        [ForeignKey("IDPersonGetter")]
        virtual public Person PersonGetter { get; set; }


    }
}
