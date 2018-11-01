namespace Courswork_Entity_AUTOSALE_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Years", "year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Years", "year", c => c.Double(nullable: false));
        }
    }
}
