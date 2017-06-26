using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using SellModule.Models;
using System.Collections;

namespace SellModule.Controllers
{
    public class StatisticController : Controller
    {
        private ContractContext db = new ContractContext();

        // GET: Statistic
        public ActionResult ViewStatistic()
        {
            return View();
        }

        public ActionResult SellColumns()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var result = (from c in db.Contracts select c);

            result.ToList().ForEach(rs => xValue.Add(rs.Date));
            result.ToList().ForEach(rs => yValue.Add(rs.Price));

            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("Столбчатая диаграмма")
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
                .Write("bmp");

            return null;
        }

        public ActionResult SellPie()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var result = (from c in db.Contracts select c);

            result.ToList().ForEach(rs => xValue.Add(rs.Price));
            result.ToList().ForEach(rs => yValue.Add(rs.ProductId.Count()));

            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("Круговая диаграмма")
                .AddSeries("Default", chartType: "Pie", xValue: xValue, yValues: yValue)
                .Write("bmp");

            return null;
        }
    }
}