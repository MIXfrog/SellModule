namespace SellModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "ContractStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "VendorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contracts", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CustomerTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Contracts", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "Status", c => c.String());
            AlterColumn("dbo.Customers", "CustomerTypeId", c => c.String());
            AlterColumn("dbo.Contracts", "ProductId", c => c.String());
            DropColumn("dbo.Contracts", "VendorId");
            DropColumn("dbo.Contracts", "ContractStatusId");
        }
    }
}
