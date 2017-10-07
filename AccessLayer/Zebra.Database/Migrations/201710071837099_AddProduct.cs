namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbProducts",
                c => new
                    {
                        ProuductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProuductId)
                .ForeignKey("dbo.DbCompanies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbProducts", "CompanyId", "dbo.DbCompanies");
            DropIndex("dbo.DbProducts", new[] { "CompanyId" });
            DropTable("dbo.DbProducts");
        }
    }
}
