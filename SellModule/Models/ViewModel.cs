using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellModule.Models
{
    public class ViewModel
    {
        public IEnumerable<Contract> Contracts { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<CustomerType> CustomerTypes { get; set; }
        public IEnumerable<ContractStatus> ContractStatuses { get; set; }
    }
}