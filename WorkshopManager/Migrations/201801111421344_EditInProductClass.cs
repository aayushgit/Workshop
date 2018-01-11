namespace WorkshopManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditInProductClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ModelNo", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "ModelNo");
        }
    }
}
