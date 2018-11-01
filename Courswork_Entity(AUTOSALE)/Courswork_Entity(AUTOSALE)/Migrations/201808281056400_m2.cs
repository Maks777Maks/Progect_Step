namespace Courswork_Entity_AUTOSALE_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characteristics", "Name_UA", c => c.String(nullable: false));
            AddColumn("dbo.Characteristics", "Name_RUS", c => c.String(nullable: false));
            AddColumn("dbo.Characteristics", "Name_EN", c => c.String(nullable: false));
            AddColumn("dbo.Fuels", "Fuel_UA", c => c.String(nullable: false));
            AddColumn("dbo.Fuels", "Fuel_RUS", c => c.String(nullable: false));
            AddColumn("dbo.Fuels", "Fuel_EN", c => c.String(nullable: false));
            AddColumn("dbo.Headings", "Name_UA", c => c.String(nullable: false));
            AddColumn("dbo.Headings", "Name_RUS", c => c.String(nullable: false));
            AddColumn("dbo.Headings", "Name_EN", c => c.String(nullable: false));
            AddColumn("dbo.Transmissions", "transmission_UA", c => c.String(nullable: false));
            AddColumn("dbo.Transmissions", "transmission_RUS", c => c.String(nullable: false));
            AddColumn("dbo.Transmissions", "transmission_EN", c => c.String(nullable: false));
            AddColumn("dbo.Cities", "Name_UA", c => c.String(nullable: false));
            AddColumn("dbo.Cities", "Name_RUS", c => c.String(nullable: false));
            AddColumn("dbo.Cities", "Name_EN", c => c.String(nullable: false));
            DropColumn("dbo.Characteristics", "Name");
            DropColumn("dbo.Fuels", "fuel");
            DropColumn("dbo.Headings", "Name");
            DropColumn("dbo.Transmissions", "transmission");
            DropColumn("dbo.Cities", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "Name", c => c.String());
            AddColumn("dbo.Transmissions", "transmission", c => c.String());
            AddColumn("dbo.Headings", "Name", c => c.String());
            AddColumn("dbo.Fuels", "fuel", c => c.String());
            AddColumn("dbo.Characteristics", "Name", c => c.String());
            DropColumn("dbo.Cities", "Name_EN");
            DropColumn("dbo.Cities", "Name_RUS");
            DropColumn("dbo.Cities", "Name_UA");
            DropColumn("dbo.Transmissions", "transmission_EN");
            DropColumn("dbo.Transmissions", "transmission_RUS");
            DropColumn("dbo.Transmissions", "transmission_UA");
            DropColumn("dbo.Headings", "Name_EN");
            DropColumn("dbo.Headings", "Name_RUS");
            DropColumn("dbo.Headings", "Name_UA");
            DropColumn("dbo.Fuels", "Fuel_EN");
            DropColumn("dbo.Fuels", "Fuel_RUS");
            DropColumn("dbo.Fuels", "Fuel_UA");
            DropColumn("dbo.Characteristics", "Name_EN");
            DropColumn("dbo.Characteristics", "Name_RUS");
            DropColumn("dbo.Characteristics", "Name_UA");
        }
    }
}
