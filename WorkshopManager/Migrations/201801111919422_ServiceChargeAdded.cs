namespace WorkshopManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceChargeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTypes", "ServiceCharge", c => c.Byte(nullable: false));
            DropColumn("dbo.ProductTypes", "DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductTypes", "DiscountRate", c => c.Byte(nullable: false));
            DropColumn("dbo.ProductTypes", "ServiceCharge");
        }
    }
}
