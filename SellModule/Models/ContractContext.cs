using SellModule.Models;
using System.Data.Entity;

namespace SellModule.Models
{
    public class ContractContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
    }
}