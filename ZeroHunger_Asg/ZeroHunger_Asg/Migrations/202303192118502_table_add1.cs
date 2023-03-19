namespace ZeroHunger_Asg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table_add1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Contact", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Password", c => c.String());
            AlterColumn("dbo.Restaurants", "Username", c => c.String());
            AlterColumn("dbo.Restaurants", "Email", c => c.String());
            AlterColumn("dbo.Restaurants", "Contact", c => c.String());
            AlterColumn("dbo.Restaurants", "Address", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
        }
    }
}
