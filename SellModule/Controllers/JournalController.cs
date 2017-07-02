using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellModule.Models;

namespace SellModule.Controllers
{
    public class JournalController : Controller
    {
        private ContractContext db = new ContractContext();

        public ViewResult ViewJournal()
        {
            var model = db.Contracts.Include("Customer").Include("ProductType").ToList();
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            Contract contract = db.Contracts.Find(id);
            
            return View();
        }

        public ViewResult Delete()
        {
            return View();
        }
}
}