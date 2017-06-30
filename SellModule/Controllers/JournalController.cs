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
        ContractContext db = new ContractContext();

        public ViewResult ViewJournal()
        {
            return View(db.Contracts.ToList());
        }

        public ViewResult Edit()
        {
            return View();
        }

        public ViewResult Delete()
        {
            return View();
        }
}
}