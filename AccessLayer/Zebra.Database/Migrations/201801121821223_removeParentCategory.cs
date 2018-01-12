namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeParentCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropColumn("dbo.Categories", "ParentCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ParentCategoryId", c => c.Int());
            CreateIndex("dbo.Categories", "ParentCategoryId");
            AddForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
