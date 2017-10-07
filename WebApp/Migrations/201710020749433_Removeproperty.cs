namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removeproperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
