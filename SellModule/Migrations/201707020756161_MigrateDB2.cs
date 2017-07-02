namespace SellModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "CustomerType_CustomerTypeId", c => c.Int());
            CreateIndex("dbo.Contracts", "ProductId");
            CreateIndex("dbo.Contracts", "ContractStatusId");
            CreateIndex("dbo.Contracts", "CustomerId");
            CreateIndex("dbo.Contracts", "CustomerType_CustomerTypeId");
            AddForeignKey("dbo.Contracts", "ContractStatusId", "dbo.ContractStatus", "ContractStatusId", cascadeDelete: true);
            AddForeignKey("dbo.Contracts", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Contracts", "CustomerType_CustomerTypeId", "dbo.CustomerTypes", "CustomerTypeId");
            AddForeignKey("dbo.Contracts", "ProductId", "dbo.ProductTypes", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "ProductId", "dbo.ProductTypes");
            DropForeignKey("dbo.Contracts", "CustomerType_CustomerTypeId", "dbo.CustomerTypes");
            DropForeignKey("dbo.Contracts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Contracts", "ContractStatusId", "dbo.ContractStatus");
            DropIndex("dbo.Contracts", new[] { "CustomerType_CustomerTypeId" });
            DropIndex("dbo.Contracts", new[] { "CustomerId" });
            DropIndex("dbo.Contracts", new[] { "ContractStatusId" });
            DropIndex("dbo.Contracts", new[] { "ProductId" });
            DropColumn("dbo.Contracts", "CustomerType_CustomerTypeId");
        }
    }
}
