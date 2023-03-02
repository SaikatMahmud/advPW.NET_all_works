namespace CodeFirstPractice_Ecom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKey_fixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Orders", "CusId");
            DropColumn("dbo.Products", "CatId");
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CusId");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CatId");
            AlterColumn("dbo.Categories", "CatName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "CusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Price", c => c.Single());
            AlterColumn("dbo.Products", "CatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CatId");
            CreateIndex("dbo.Orders", "CusId");
            AddForeignKey("dbo.Orders", "CusId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CatId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatId", "dbo.Categories");
            DropForeignKey("dbo.Orders", "CusId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CusId" });
            DropIndex("dbo.Products", new[] { "CatId" });
            AlterColumn("dbo.Products", "CatId", c => c.Int());
            AlterColumn("dbo.Products", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Orders", "CusId", c => c.Int());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Categories", "CatName", c => c.String());
            RenameColumn(table: "dbo.Products", name: "CatId", newName: "Category_Id");
            RenameColumn(table: "dbo.Orders", name: "CusId", newName: "Customer_Id");
            AddColumn("dbo.Products", "CatId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
