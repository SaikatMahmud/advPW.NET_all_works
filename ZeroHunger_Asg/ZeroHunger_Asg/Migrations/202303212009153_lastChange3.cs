namespace ZeroHunger_Asg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastChange3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            AlterColumn("dbo.Foods", "RestaurantId", c => c.Int());
            CreateIndex("dbo.Foods", "RestaurantId");
            AddForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            AlterColumn("dbo.Foods", "RestaurantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Foods", "RestaurantId");
            AddForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
    }
}
