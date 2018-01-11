namespace WorkshopManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTypeAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "ProductTypeId_Id", c => c.Int());
            CreateIndex("dbo.Products", "ProductTypeId_Id");
            AddForeignKey("dbo.Products", "ProductTypeId_Id", "dbo.ProductTypes", "Id");
            DropColumn("dbo.Products", "IsOfType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsOfType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "ProductTypeId_Id", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeId_Id" });
            DropColumn("dbo.Products", "ProductTypeId_Id");
            DropTable("dbo.ProductTypes");
        }
    }
}
