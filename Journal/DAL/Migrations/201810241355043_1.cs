namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        mark = c.Int(nullable: false),
                        student_ID = c.Int(),
                        subject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.student_ID)
                .ForeignKey("dbo.Subjects", t => t.subject_ID)
                .Index(t => t.student_ID)
                .Index(t => t.subject_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_ID, t.Student_ID })
                .ForeignKey("dbo.Subjects", t => t.Subject_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.Subject_ID)
                .Index(t => t.Student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.SubjectStudents", "Subject_ID", "dbo.Subjects");
            DropForeignKey("dbo.Marks", "subject_ID", "dbo.Subjects");
            DropForeignKey("dbo.Marks", "student_ID", "dbo.Students");
            DropIndex("dbo.SubjectStudents", new[] { "Student_ID" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_ID" });
            DropIndex("dbo.Marks", new[] { "subject_ID" });
            DropIndex("dbo.Marks", new[] { "student_ID" });
            DropTable("dbo.SubjectStudents");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Marks");
        }
    }
}
