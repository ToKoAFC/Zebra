namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.DbCategories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.ProductId })
                .ForeignKey("dbo.DbCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.DbProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "ProductId", "dbo.DbProducts");
            DropForeignKey("dbo.ProductCategories", "CategoryId", "dbo.DbCategories");
            DropForeignKey("dbo.DbCategories", "ParentCategoryId", "dbo.DbCategories");
            DropIndex("dbo.ProductCategories", new[] { "ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "CategoryId" });
            DropIndex("dbo.DbCategories", new[] { "ParentCategoryId" });
            DropTable("dbo.ProductCategories");
            DropTable("dbo.DbCategories");
        }
    }
}
