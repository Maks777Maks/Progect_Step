namespace Entity_Code_First_
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        
        public Model1()
            : base("name=Model1")
        {
        }

        virtual public DbSet<Person> Persons { get; set; }
        virtual public DbSet<Message> Messages { get; set; }  
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}