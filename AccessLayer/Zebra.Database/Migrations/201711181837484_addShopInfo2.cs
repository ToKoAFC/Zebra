namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addShopInfo2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopInfo",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        NIP = c.String(),
                        Regon = c.String(),
                        Country = c.String(),
                        Region = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                    })
                .PrimaryKey(t => t.ShopId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShopInfo");
        }
    }
}
