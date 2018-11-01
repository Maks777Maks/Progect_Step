namespace ConsoleApplication2
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
        virtual public DbSet<City> Cityes { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}