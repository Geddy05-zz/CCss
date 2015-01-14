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

namespace Simple_solutions.Controllers
{
    public class AdminController : Controller
    {
        AdminContext db = new AdminContext();
        //
        // GET: /Admin/

        public ActionResult Login()
        {
            ViewBag.Message = "Test Test";
            return View(db.SearchPropertiesModels.ToList());
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Test Test";
            return View();
        }

        public ActionResult Sold()
        {


            return View(db.selleds.GroupBy(s => s.url).Select(g => g.OrderByDescending(p => p.productName).FirstOrDefault()));
        }

        public ActionResult Search()
        {

            return View(db.SearchPropertiesModels.ToList());
        }


    }
}
