namespace TPSupPWD.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TP1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pwds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampusId = c.Int(nullable: false),
                        Lastname = c.String(nullable: false),
                        Firstname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pwds", "StudentId", "dbo.Students");
            DropIndex("dbo.Pwds", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Pwds");
        }
    }
}
