namespace ConsoleApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Sex = c.String(),
                        Phone = c.String(),
                        IDCity = c.Int(nullable: false),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .Index(t => t.City_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "City_ID", "dbo.Cities");
            DropIndex("dbo.People", new[] { "City_ID" });
            DropTable("dbo.People");
            DropTable("dbo.Cities");
        }
    }
}
