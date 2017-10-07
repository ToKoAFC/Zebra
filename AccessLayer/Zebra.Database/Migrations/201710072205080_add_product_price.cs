namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_product_price : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbProductPrices",
                c => new
                    {
                        ProductPriceId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductPriceId)
                .ForeignKey("dbo.DbProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbProductPrices", "ProductId", "dbo.DbProducts");
            DropIndex("dbo.DbProductPrices", new[] { "ProductId" });
            DropTable("dbo.DbProductPrices");
        }
    }
}
