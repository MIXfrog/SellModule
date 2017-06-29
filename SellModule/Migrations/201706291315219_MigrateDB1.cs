namespace SellModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleClasses",
                c => new
                    {
                        VehicleClassId = c.Int(nullable: false, identity: true),
                        VehicleClassName = c.String(),
                    })
                .PrimaryKey(t => t.VehicleClassId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VIN = c.Int(nullable: false, identity: true),
                        ModelCode = c.String(),
                        VehicleClassId = c.Int(nullable: false),
                        YearMade = c.DateTime(nullable: false),
                        VehicleDetails = c.String(),
                    })
                .PrimaryKey(t => t.VIN);
            
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.ProductTypes", "VIN", c => c.Int(nullable: false));
            AddColumn("dbo.Vendors", "Login", c => c.String());
            AddColumn("dbo.Vendors", "Password", c => c.String());
            AddColumn("dbo.Vendors", "Email", c => c.String());
            DropColumn("dbo.Customers", "Adress");
            DropColumn("dbo.Vendors", "VendorLogin");
            DropColumn("dbo.Vendors", "VendorPassword");
            DropColumn("dbo.Vendors", "VendorEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendors", "VendorEmail", c => c.String());
            AddColumn("dbo.Vendors", "VendorPassword", c => c.String());
            AddColumn("dbo.Vendors", "VendorLogin", c => c.String());
            AddColumn("dbo.Customers", "Adress", c => c.String());
            DropColumn("dbo.Vendors", "Email");
            DropColumn("dbo.Vendors", "Password");
            DropColumn("dbo.Vendors", "Login");
            DropColumn("dbo.ProductTypes", "VIN");
            DropColumn("dbo.Customers", "Address");
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleClasses");
        }
    }
}
