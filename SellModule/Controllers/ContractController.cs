using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellModule.Models;

namespace SellModule.Controllers
{
    public class ContractController : Controller
    {
        ContractContext db = new ContractContext();

        public ActionResult CreateContract()
        {
            //Get the value from database and then set it to ViewBag to pass it View
            IEnumerable<SelectListItem> items =
                db.Contracts.Select(c => new SelectListItem
                {
                    Value = c.CustomerName,
                    Text = c.CustomerName

                }
                ).Distinct();

            ViewBag.CustomerList = items;

            return View();
        }

        [HttpPost]
        public ActionResult CreateContract
            (string CustomerName, string ProductType, decimal Price,
            DateTime Date, string CustomerType, int BankNumber, string Adress)
        {
            Contract contract = new Contract
            {
                CustomerName = CustomerName,
                ProductType = ProductType,
                Price = Price,
                Date = Date,
                CustomerType = CustomerType,
                BankNumber = BankNumber,
                Adress = Adress,
                Status = "Sold"
            };

            try
            {
                // Записываем котнтракт в БД\
                db.Contracts.Add(contract);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}