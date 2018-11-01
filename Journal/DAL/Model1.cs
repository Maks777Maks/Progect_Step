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
        virtual public DbSet<Student> Students { get; set; }
        virtual public DbSet<Mark> Marks { get; set; }
        virtual public DbSet<Subject> Subjects { get; set; }
    }

    
}