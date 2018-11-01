using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Person_
{    
    public class Friends : IFriends
    {
        public List<Person> GetFriends(Person p)
        {

            List<Person> persons = new List<Person> {
                new Person { Name = "Ivan", Age = 22 },
                new Person { Name = "Oleg", Age = 25 },
                new Person { Name = "Masha", Age = 18 },
                new Person { Name = "Dasha", Age = 19 }
            } ;
            return persons;
        }
        
    }
}
