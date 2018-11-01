namespace DAL
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
        virtual public DbSet<Teacher> Teacher { get; set; }
        virtual public DbSet<Course> Course { get; set; }
        virtual public DbSet<Student> Student { get; set; }

    }

    
}