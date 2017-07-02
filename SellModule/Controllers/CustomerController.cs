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

        public ViewResult AddCustomer()
        {
            IEnumerable<SelectListItem> selectCustomerTypeList =
                from s in db.CustomerTypes // where ever you get this from, database etc.
                            select new SelectListItem
                {
                    Text = s.CustomerTypeName,
                    Value = s.CustomerTypeId.ToString()
                };

            ViewBag.CustomerTypes = selectCustomerTypeList;


            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer
            (string CustomerTypeId, string CustomerName,
            int BankNumber, string Address)
        {
            Customer customer = new Customer
            {
                CustomerTypeId = Convert.ToInt32(CustomerTypeId),
                CustomerName = CustomerName,
                BankNumber = BankNumber,
                Address = Address
            };

            try
            {
                // Записываем котнтракт в БД\
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return RedirectToAction("ViewJournal", "Journal");
        }
    }
}