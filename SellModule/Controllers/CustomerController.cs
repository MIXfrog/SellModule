using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellModule.Models;

namespace SellModule.Controllers
{
    public class CustomerController : Controller
    {
        private ContractContext db = new ContractContext();

        public ViewResult ViewCustomerList()
        {
            var model = db.Customers.Include("CustomerType").ToList();
            return View(model);
        }
    }
}