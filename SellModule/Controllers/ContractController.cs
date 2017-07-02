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
            // Необходимо закинуть данные о клиентах, статусах продукта. Создаем список
            IEnumerable<SelectListItem> selectCustomerTypeList =
                from s in db.CustomerTypes // where ever you get this from, database etc.
                            select new SelectListItem
                            {
                                Text = s.CustomerTypeName,
                                Value = s.CustomerTypeId.ToString()
                            };
            ViewBag.ClientTypes = selectCustomerTypeList;

            IEnumerable<SelectListItem> selectProductTypeList =
                from s in db.ProductTypes // where ever you get this from, database etc.
                            select new SelectListItem
                            {
                                Text = s.ProductName,
                                Value = s.ProductId.ToString()
                            };
            ViewBag.ProductTypes = selectProductTypeList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateContract
            (string ProductId, decimal Price,
            DateTime Date, string CustomerId)
        {
            Contract contract = new Contract
            {
                ProductId = Convert.ToInt32(ProductId),
                Price = Price,
                Date = Date,
                CustomerId = Convert.ToInt32(CustomerId),
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

        [HttpPost]
        public ActionResult GetCustomersByCustomerTypeId(string CustomerTypeId)
        {
            int customerTypeId = Convert.ToInt32(CustomerTypeId);
            List<Customer> objContract = new List<Customer>();

            // ПОЛУЧАЕМ СПИСОК КЛИЕНТОВ ПО CustomerTypeId
            objContract = db.Customers.ToList().Where(m => m.CustomerTypeId == customerTypeId).ToList();

            SelectList obgContract = new SelectList(objContract, "CustomerId", "CustomerName", 0);
            return Json(obgContract);
        }

        [HttpPost]
        public ActionResult GetAdressByCustomerId(string CustomerId)
        {
            int customerId = Convert.ToInt32(CustomerId);
            List<Customer> objContract = new List<Customer>();

            // ПОЛУЧАЕМ СПИСОК КЛИЕНТОВ ПО CustomerTypeId
            objContract = db.Customers.ToList().Where(m => m.CustomerId == customerId).ToList();

            SelectList obgContract = new SelectList(objContract, "CustomerId", "CustomerName", 0);
            return Json(obgContract);
        }

        [HttpPost]
        public ActionResult FillAddressAndBankNumber_OnClientNameChange(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(sender);

            var query = from c in db.Customers
                        where c.CustomerId == id
                        select c;

            return Json(query);
        }
    }
}