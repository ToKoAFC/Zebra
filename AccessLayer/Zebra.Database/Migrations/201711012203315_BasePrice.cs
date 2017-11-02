namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasePrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "BasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "BasePrice");
        }
    }
}
