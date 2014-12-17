using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_solutions.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Login()
        {
            ViewBag.Message = "Test Test";
            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Test Test";
            return View();
        }

    }
}
