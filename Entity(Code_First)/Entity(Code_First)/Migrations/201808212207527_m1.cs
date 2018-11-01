namespace Entity_Code_First_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        IDPersonSender = c.Int(),
                        IDPersonGetter = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.IDPersonGetter)
                .ForeignKey("dbo.People", t => t.IDPersonSender)
                .Index(t => t.IDPersonSender)
                .Index(t => t.IDPersonGetter);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "IDPersonSender", "dbo.People");
            DropForeignKey("dbo.Messages", "IDPersonGetter", "dbo.People");
            DropIndex("dbo.Messages", new[] { "IDPersonGetter" });
            DropIndex("dbo.Messages", new[] { "IDPersonSender" });
            DropTable("dbo.People");
            DropTable("dbo.Messages");
        }
    }
}
