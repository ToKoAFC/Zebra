namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDiscount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountId);
            
            CreateTable(
                "dbo.DbDiscountDbCategories",
                c => new
                    {
                        DbDiscount_DiscountId = c.Int(nullable: false),
                        DbCategory_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DbDiscount_DiscountId, t.DbCategory_CategoryId })
                .ForeignKey("dbo.Discounts", t => t.DbDiscount_DiscountId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.DbCategory_CategoryId, cascadeDelete: true)
                .Index(t => t.DbDiscount_DiscountId)
                .Index(t => t.DbCategory_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbDiscountDbCategories", "DbCategory_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.DbDiscountDbCategories", "DbDiscount_DiscountId", "dbo.Discounts");
            DropIndex("dbo.DbDiscountDbCategories", new[] { "DbCategory_CategoryId" });
            DropIndex("dbo.DbDiscountDbCategories", new[] { "DbDiscount_DiscountId" });
            DropTable("dbo.DbDiscountDbCategories");
            DropTable("dbo.Discounts");
        }
    }
}
