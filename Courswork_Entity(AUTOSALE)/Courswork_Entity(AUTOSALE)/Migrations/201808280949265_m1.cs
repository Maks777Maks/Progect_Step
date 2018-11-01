namespace Courswork_Entity_AUTOSALE_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        _text = c.String(nullable: false),
                        _miliage = c.String(nullable: false),
                        _price = c.Int(nullable: false),
                        _brand = c.String(nullable: false),
                        _model = c.String(nullable: false),
                        _engine_ID = c.Int(),
                        _fuel_ID = c.Int(),
                        _heading_ID = c.Int(),
                        _transmission_ID = c.Int(),
                        _user_ID = c.Int(),
                        _year_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Engines", t => t._engine_ID)
                .ForeignKey("dbo.Fuels", t => t._fuel_ID)
                .ForeignKey("dbo.Headings", t => t._heading_ID)
                .ForeignKey("dbo.Transmissions", t => t._transmission_ID)
                .ForeignKey("dbo.Users", t => t._user_ID)
                .ForeignKey("dbo.Years", t => t._year_ID)
                .Index(t => t._engine_ID)
                .Index(t => t._fuel_ID)
                .Index(t => t._heading_ID)
                .Index(t => t._transmission_ID)
                .Index(t => t._user_ID)
                .Index(t => t._year_ID);
            
            CreateTable(
                "dbo.Characteristics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        engine = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        fuel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Ads_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ads", t => t.Ads_ID)
                .Index(t => t.Ads_ID);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        transmission = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        _login = c.String(nullable: false),
                        _password = c.String(nullable: false),
                        _name = c.String(nullable: false),
                        _tel = c.String(nullable: false),
                        _mail = c.String(nullable: false),
                        _city_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t._city_ID)
                .Index(t => t._city_ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        year = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Bus_Brand",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Bus_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        Bus_Brand_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bus_Brand", t => t.Bus_Brand_ID)
                .Index(t => t.Bus_Brand_ID);
            
            CreateTable(
                "dbo.Car_Brand",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Car_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        Car_Brand_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car_Brand", t => t.Car_Brand_ID)
                .Index(t => t.Car_Brand_ID);
            
            CreateTable(
                "dbo.Moto_Brand",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Moto_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        Moto_Brand_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Moto_Brand", t => t.Moto_Brand_ID)
                .Index(t => t.Moto_Brand_ID);
            
            CreateTable(
                "dbo.Trucks_Brand",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trucs_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        Trucks_Brand_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trucks_Brand", t => t.Trucks_Brand_ID)
                .Index(t => t.Trucks_Brand_ID);
            
            CreateTable(
                "dbo.CharacteristicAds",
                c => new
                    {
                        Characteristic_ID = c.Int(nullable: false),
                        Ads_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Characteristic_ID, t.Ads_ID })
                .ForeignKey("dbo.Characteristics", t => t.Characteristic_ID, cascadeDelete: true)
                .ForeignKey("dbo.Ads", t => t.Ads_ID, cascadeDelete: true)
                .Index(t => t.Characteristic_ID)
                .Index(t => t.Ads_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trucs_Model", "Trucks_Brand_ID", "dbo.Trucks_Brand");
            DropForeignKey("dbo.Moto_Model", "Moto_Brand_ID", "dbo.Moto_Brand");
            DropForeignKey("dbo.Car_Model", "Car_Brand_ID", "dbo.Car_Brand");
            DropForeignKey("dbo.Bus_Model", "Bus_Brand_ID", "dbo.Bus_Brand");
            DropForeignKey("dbo.Ads", "_year_ID", "dbo.Years");
            DropForeignKey("dbo.Users", "_city_ID", "dbo.Cities");
            DropForeignKey("dbo.Ads", "_user_ID", "dbo.Users");
            DropForeignKey("dbo.Ads", "_transmission_ID", "dbo.Transmissions");
            DropForeignKey("dbo.Images", "Ads_ID", "dbo.Ads");
            DropForeignKey("dbo.Ads", "_heading_ID", "dbo.Headings");
            DropForeignKey("dbo.Ads", "_fuel_ID", "dbo.Fuels");
            DropForeignKey("dbo.Ads", "_engine_ID", "dbo.Engines");
            DropForeignKey("dbo.CharacteristicAds", "Ads_ID", "dbo.Ads");
            DropForeignKey("dbo.CharacteristicAds", "Characteristic_ID", "dbo.Characteristics");
            DropIndex("dbo.CharacteristicAds", new[] { "Ads_ID" });
            DropIndex("dbo.CharacteristicAds", new[] { "Characteristic_ID" });
            DropIndex("dbo.Trucs_Model", new[] { "Trucks_Brand_ID" });
            DropIndex("dbo.Moto_Model", new[] { "Moto_Brand_ID" });
            DropIndex("dbo.Car_Model", new[] { "Car_Brand_ID" });
            DropIndex("dbo.Bus_Model", new[] { "Bus_Brand_ID" });
            DropIndex("dbo.Users", new[] { "_city_ID" });
            DropIndex("dbo.Images", new[] { "Ads_ID" });
            DropIndex("dbo.Ads", new[] { "_year_ID" });
            DropIndex("dbo.Ads", new[] { "_user_ID" });
            DropIndex("dbo.Ads", new[] { "_transmission_ID" });
            DropIndex("dbo.Ads", new[] { "_heading_ID" });
            DropIndex("dbo.Ads", new[] { "_fuel_ID" });
            DropIndex("dbo.Ads", new[] { "_engine_ID" });
            DropTable("dbo.CharacteristicAds");
            DropTable("dbo.Trucs_Model");
            DropTable("dbo.Trucks_Brand");
            DropTable("dbo.Moto_Model");
            DropTable("dbo.Moto_Brand");
            DropTable("dbo.Car_Model");
            DropTable("dbo.Car_Brand");
            DropTable("dbo.Bus_Model");
            DropTable("dbo.Bus_Brand");
            DropTable("dbo.Years");
            DropTable("dbo.Cities");
            DropTable("dbo.Users");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Images");
            DropTable("dbo.Headings");
            DropTable("dbo.Fuels");
            DropTable("dbo.Engines");
            DropTable("dbo.Characteristics");
            DropTable("dbo.Ads");
        }
    }
}
