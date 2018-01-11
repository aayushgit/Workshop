namespace WorkshopManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsOfTypeInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsOfType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsOfType");
        }
    }
}
