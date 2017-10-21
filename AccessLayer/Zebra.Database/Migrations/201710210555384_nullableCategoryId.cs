namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableCategoryId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            AlterColumn("dbo.Categories", "ParentCategoryId", c => c.Int());
            CreateIndex("dbo.Categories", "ParentCategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            AlterColumn("dbo.Categories", "ParentCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "ParentCategoryId");
        }
    }
}
