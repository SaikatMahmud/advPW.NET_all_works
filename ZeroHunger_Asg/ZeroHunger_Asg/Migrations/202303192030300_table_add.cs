namespace ZeroHunger_Asg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                        FoodType = c.String(),
                        Quantity = c.String(),
                        Status = c.String(),
                        PreserveTime = c.Int(nullable: false),
                        DistributedOn = c.String(),
                        DistributeTime = c.DateTime(nullable: false),
                        CollectionStaffId = c.Int(),
                        DistributeStaffId = c.Int(),
                        Staff_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staffs", t => t.Staff_Id)
                .ForeignKey("dbo.Staffs", t => t.CollectionStaffId)
                .ForeignKey("dbo.Staffs", t => t.DistributeStaffId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.CollectionStaffId)
                .Index(t => t.DistributeStaffId)
                .Index(t => t.Staff_Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Foods", "DistributeStaffId", "dbo.Staffs");
            DropForeignKey("dbo.Foods", "CollectionStaffId", "dbo.Staffs");
            DropForeignKey("dbo.Foods", "Staff_Id", "dbo.Staffs");
            DropIndex("dbo.Foods", new[] { "Staff_Id" });
            DropIndex("dbo.Foods", new[] { "DistributeStaffId" });
            DropIndex("dbo.Foods", new[] { "CollectionStaffId" });
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.Staffs");
            DropTable("dbo.Foods");
            DropTable("dbo.Admins");
        }
    }
}
