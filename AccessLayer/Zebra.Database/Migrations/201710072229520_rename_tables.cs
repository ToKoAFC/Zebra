namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_tables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DbCategories", newName: "Categories");
            RenameTable(name: "dbo.DbProducts", newName: "Products");
            RenameTable(name: "dbo.DbCompanies", newName: "Companies");
            RenameTable(name: "dbo.DbProductPrices", newName: "ProductPrices");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductPrices", newName: "DbProductPrices");
            RenameTable(name: "dbo.Companies", newName: "DbCompanies");
            RenameTable(name: "dbo.Products", newName: "DbProducts");
            RenameTable(name: "dbo.Categories", newName: "DbCategories");
        }
    }
}
