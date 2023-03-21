namespace ZeroHunger_Asg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastChange2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "RequestTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "RequestTime", c => c.DateTime(nullable: false));
        }
    }
}
