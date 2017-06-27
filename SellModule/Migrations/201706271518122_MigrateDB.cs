namespace SellModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerTypeId = c.String(),
                        CustomerName = c.String(),
                        BankNumber = c.Int(nullable: false),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        CustomerTypeId = c.Int(nullable: false, identity: true),
                        CustomerTypeName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerTypeId);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            AddColumn("dbo.Contracts", "ProductId", c => c.String());
            AddColumn("dbo.Contracts", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Contracts", "ProductType");
            DropColumn("dbo.Contracts", "CustomerType");
            DropColumn("dbo.Contracts", "CustomerName");
            DropColumn("dbo.Contracts", "BankNumber");
            DropColumn("dbo.Contracts", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "Adress", c => c.String());
            AddColumn("dbo.Contracts", "BankNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "CustomerName", c => c.String());
            AddColumn("dbo.Contracts", "CustomerType", c => c.String());
            AddColumn("dbo.Contracts", "ProductType", c => c.String());
            DropColumn("dbo.Contracts", "CustomerId");
            DropColumn("dbo.Contracts", "ProductId");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.CustomerTypes");
            DropTable("dbo.Customers");
        }
    }
}
