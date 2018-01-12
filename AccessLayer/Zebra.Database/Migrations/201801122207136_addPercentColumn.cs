namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPercentColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discounts", "DiscountPercent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discounts", "DiscountPercent");
        }
    }
}
