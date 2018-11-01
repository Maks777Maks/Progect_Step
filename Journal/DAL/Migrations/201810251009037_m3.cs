namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectStudents", "Subject_ID", "dbo.Subjects");
            DropForeignKey("dbo.SubjectStudents", "Student_ID", "dbo.Students");
            DropIndex("dbo.SubjectStudents", new[] { "Subject_ID" });
            DropIndex("dbo.SubjectStudents", new[] { "Student_ID" });
            DropTable("dbo.SubjectStudents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_ID, t.Student_ID });
            
            CreateIndex("dbo.SubjectStudents", "Student_ID");
            CreateIndex("dbo.SubjectStudents", "Subject_ID");
            AddForeignKey("dbo.SubjectStudents", "Student_ID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.SubjectStudents", "Subject_ID", "dbo.Subjects", "ID", cascadeDelete: true);
        }
    }
}
