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

        //
        // GET: /Admin/

        public ActionResult Login()
        {
            AdminContext db = new AdminContext();
            ViewBag.Message = "Test Test";
            return View(db.SearchPropertiesModels.ToList());
        }

        public ActionResult Admin()
        {
             AdminContext db = new AdminContext();
            ViewBag.Message = "Test Test";
            return View();
        }

    }
}
