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
            // Необходимо закинуть данные о клиентах, статусах продукта
            return View();
        }

        [HttpPost]
        public ActionResult CreateContract
            (int ProductId, decimal Price,
            DateTime Date, int CustomerId)
        {
            Contract contract = new Contract
            {
                ProductId = ProductId,
                Price = Price,
                Date = Date,
                CustomerId = CustomerId,
                ContractStatusId = 1,
                VendorId = 1
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