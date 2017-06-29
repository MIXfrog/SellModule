using SellModule.Models;
using System.Data.Entity;

namespace SellModule.Models
{
    public class ContractContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<VendorRole> VendorRoles { get; set; }

        public DbSet<ContractStatus> ContractStatus { get; set; }

        public DbSet<Vehicle> Vvehices { get; set; }

        public DbSet<VehicleClass> VehicleClasses { get; set; }
    }
}