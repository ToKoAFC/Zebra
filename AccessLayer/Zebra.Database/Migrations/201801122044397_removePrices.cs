namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePrices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductPrices", new[] { "ProductId" });
            DropTable("dbo.ProductPrices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductPrices",
                c => new
                    {
                        ProductPriceId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductPriceId);
            
            CreateIndex("dbo.ProductPrices", "ProductId");
            AddForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products", "ProuductId", cascadeDelete: true);
        }
    }
}
