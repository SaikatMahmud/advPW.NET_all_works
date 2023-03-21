namespace ZeroHunger_Asg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodEdittest3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "User_Id", "dbo.Users");
            DropIndex("dbo.Foods", new[] { "User_Id" });
            DropColumn("dbo.Foods", "CollectionStaffId");
            DropColumn("dbo.Foods", "DistributeStaffId");
            DropColumn("dbo.Foods", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "User_Id", c => c.Int());
            AddColumn("dbo.Foods", "DistributeStaffId", c => c.Int());
            AddColumn("dbo.Foods", "CollectionStaffId", c => c.Int());
            CreateIndex("dbo.Foods", "User_Id");
            AddForeignKey("dbo.Foods", "User_Id", "dbo.Users", "Id");
        }
    }
}
