namespace Courswork_Entity_AUTOSALE_
{
    using Library1;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Base_Autosale : DbContext
    {       
        public Base_Autosale()
            : base("name=Base_Autosale")
        {
        }
        virtual public DbSet<User> Users { get; set; }
        virtual public DbSet<Image> Images { get; set; }
        virtual public DbSet<Heading> Headings { get; set; }
        virtual public DbSet<City> Cities { get; set; }
        virtual public DbSet<Characteristic> Characteristics { get; set; }
        virtual public DbSet<Ads> Ads { get; set; }
        virtual public DbSet<Year> Years { get; set; }
        virtual public DbSet<Transmission> Transmissions { get; set; }
        virtual public DbSet<Fuel> Fuels { get; set; }
        virtual public DbSet<Engine> Engines { get; set; }
        virtual public DbSet<Trucks_Brand> Trucks_Brand { get; set; }
        virtual public DbSet<Trucs_Model> Trucs_Model { get; set; }
        virtual public DbSet<Moto_Brand> Moto_Brand { get; set; }
        virtual public DbSet<Moto_Model> Moto_Model { get; set; }
        virtual public DbSet<Car_Brand> Car_Brand { get; set; }
        virtual public DbSet<Car_Model> Car_Model { get; set; }
        virtual public DbSet<Bus_Brand> Bus_Brand { get; set; }
        virtual public DbSet<Bus_Model> Bus_Model { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}