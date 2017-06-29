namespace SellModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB_021 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractStatus",
                c => new
                    {
                        ContractStatusId = c.Int(nullable: false, identity: true),
                        ContractStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ContractStatusId);
            
            CreateTable(
                "dbo.VendorRoles",
                c => new
                    {
                        VendorRoleId = c.Int(nullable: false, identity: true),
                        VendorRoleName = c.String(),
                    })
                .PrimaryKey(t => t.VendorRoleId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        VendorLogin = c.String(),
                        VendorPassword = c.String(),
                        VendorName = c.String(),
                        VendorEmail = c.String(),
                        VendorRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
            DropTable("dbo.VendorRoles");
            DropTable("dbo.ContractStatus");
        }
    }
}
