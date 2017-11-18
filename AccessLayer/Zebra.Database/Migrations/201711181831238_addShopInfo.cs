namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addShopInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2048),
                        Mime = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Size = c.Long(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbFileDbProducts",
                c => new
                    {
                        DbFile_Id = c.Int(nullable: false),
                        DbProduct_ProuductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DbFile_Id, t.DbProduct_ProuductId })
                .ForeignKey("dbo.Files", t => t.DbFile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.DbProduct_ProuductId, cascadeDelete: true)
                .Index(t => t.DbFile_Id)
                .Index(t => t.DbProduct_ProuductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbFileDbProducts", "DbProduct_ProuductId", "dbo.Products");
            DropForeignKey("dbo.DbFileDbProducts", "DbFile_Id", "dbo.Files");
            DropIndex("dbo.DbFileDbProducts", new[] { "DbProduct_ProuductId" });
            DropIndex("dbo.DbFileDbProducts", new[] { "DbFile_Id" });
            DropTable("dbo.DbFileDbProducts");
            DropTable("dbo.Files");
        }
    }
}
