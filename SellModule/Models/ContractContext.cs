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
    }
}