namespace ZeroHunger_Asg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "DistributeTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "DistributeTime", c => c.DateTime(nullable: false));
        }
    }
}
