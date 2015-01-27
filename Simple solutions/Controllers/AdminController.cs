using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using Simple_solutions.Models;
using System.Drawing;
using System.IO;
using System.Web.Helpers;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Collections;

namespace Simple_solutions.Controllers
{
    public class AdminController : Controller
    {
        private DBhelper dbHelper;
        private String query;

        public ActionResult Login()
        {
            AdminContext db = new AdminContext();
            return View(db.SearchPropertiesModels.ToList());
        }

        public ActionResult Admin()
        {
            ViewBag.PageName = "priceChanges";

            dbHelper = new DBhelper();
            AdminContext db = new AdminContext();
            query = "use pcbuilder; SELECT timestamp, AVG(price) as gemiddeldePrijs, type FROM products GROUP BY timestamp, type;";

            List<String> columNames = new List<String>(3);
            columNames.Add("timestamp");
            columNames.Add("gemiddeldePrijs");
            columNames.Add("type");

            List<string>[] queryResult = dbHelper.Select(query, 2, columNames);
            ViewData["timestamp"] = queryResult[0];
            if (queryResult[1][0] != "") {
                ViewData["gemiddeldePrijs"] = queryResult[1];
            } else {
                ViewData["gemiddeldePrijs"] = queryResult[0];                
            }
            return View();
        }
    }
}
