namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableCreate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Members", new[] { "Project_Id" });
            AlterColumn("dbo.Members", "Project_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "Project_Id");
            AddForeignKey("dbo.Members", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Members", new[] { "Project_Id" });
            AlterColumn("dbo.Members", "Project_Id", c => c.Int());
            CreateIndex("dbo.Members", "Project_Id");
            AddForeignKey("dbo.Members", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
