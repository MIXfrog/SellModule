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
            return View();
        }

        [HttpPost]
        public ActionResult CreateContract
            (string ProductId, decimal Price,
            DateTime Date, int CustomerId)
        {
            Contract contract = new Contract
            {
                ProductId = ProductId,
                Price = Price,
                Date = Date,
                CustomerId = CustomerId,
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