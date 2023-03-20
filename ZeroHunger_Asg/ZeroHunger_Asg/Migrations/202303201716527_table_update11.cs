namespace ZeroHunger_Asg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table_update11 : DbMigration
    {
        public override void Up()
        {
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
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.CollectionStaffId)
                .ForeignKey("dbo.Users", t => t.DistributeStaffId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.CollectionStaffId)
                .Index(t => t.DistributeStaffId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
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
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Foods", "DistributeStaffId", "dbo.Users");
            DropForeignKey("dbo.Foods", "CollectionStaffId", "dbo.Users");
            DropForeignKey("dbo.Foods", "User_Id", "dbo.Users");
            DropIndex("dbo.Foods", new[] { "User_Id" });
            DropIndex("dbo.Foods", new[] { "DistributeStaffId" });
            DropIndex("dbo.Foods", new[] { "CollectionStaffId" });
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.Users");
            DropTable("dbo.Foods");
        }
    }
}
