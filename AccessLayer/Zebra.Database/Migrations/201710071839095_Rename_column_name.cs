namespace Zebra.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_column_name : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbProducts", "CompanyId", "dbo.DbCompanies");
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.DbCompanies");
            DropPrimaryKey("dbo.DbCompanies");
            DropColumn("dbo.DbCompanies", "Id");
            AddColumn("dbo.DbCompanies", "CompanyId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DbCompanies", "CompanyId");
            AddForeignKey("dbo.DbProducts", "CompanyId", "dbo.DbCompanies", "CompanyId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.DbCompanies", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbCompanies", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.DbCompanies");
            DropForeignKey("dbo.DbProducts", "CompanyId", "dbo.DbCompanies");
            DropPrimaryKey("dbo.DbCompanies");
            DropColumn("dbo.DbCompanies", "CompanyId");
            AddPrimaryKey("dbo.DbCompanies", "Id");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.DbCompanies", "Id");
            AddForeignKey("dbo.DbProducts", "CompanyId", "dbo.DbCompanies", "Id", cascadeDelete: true);
        }
    }
}
