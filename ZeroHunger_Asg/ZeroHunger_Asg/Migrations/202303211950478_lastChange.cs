namespace ZeroHunger_Asg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "CollectionStaffId", c => c.Int());
            AddColumn("dbo.Foods", "DistributeStaffId", c => c.Int());
            AddColumn("dbo.Foods", "User_Id", c => c.Int());
            CreateIndex("dbo.Foods", "CollectionStaffId");
            CreateIndex("dbo.Foods", "DistributeStaffId");
            CreateIndex("dbo.Foods", "User_Id");
            AddForeignKey("dbo.Foods", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Foods", "CollectionStaffId", "dbo.Users", "Id");
            AddForeignKey("dbo.Foods", "DistributeStaffId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "DistributeStaffId", "dbo.Users");
            DropForeignKey("dbo.Foods", "CollectionStaffId", "dbo.Users");
            DropForeignKey("dbo.Foods", "User_Id", "dbo.Users");
            DropIndex("dbo.Foods", new[] { "User_Id" });
            DropIndex("dbo.Foods", new[] { "DistributeStaffId" });
            DropIndex("dbo.Foods", new[] { "CollectionStaffId" });
            DropColumn("dbo.Foods", "User_Id");
            DropColumn("dbo.Foods", "DistributeStaffId");
            DropColumn("dbo.Foods", "CollectionStaffId");
        }
    }
}
