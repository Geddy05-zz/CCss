using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Simple_solutions.Models;

namespace Simple_solutions.Controllers
{
    public class selledsController : Controller
    {
        private AdminContext db = new AdminContext();

        // GET: selleds
        public ActionResult Index()
        {
            return View(db.selleds.ToList());
        }

        // GET: selleds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            selled selled = db.selleds.Find(id);
            if (selled == null)
            {
                return HttpNotFound();
            }
            return View(selled);
        }

        // GET: selleds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: selleds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,productName,url,prijs")] selled selled)
        {
            if (ModelState.IsValid)
            {
                db.selleds.Add(selled);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(selled);
        }

        // GET: selleds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            selled selled = db.selleds.Find(id);
            if (selled == null)
            {
                return HttpNotFound();
            }
            return View(selled);
        }

        // POST: selleds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,productName,url,prijs")] selled selled)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selled).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(selled);
        }

        // GET: selleds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            selled selled = db.selleds.Find(id);
            if (selled == null)
            {
                return HttpNotFound();
            }
            return View(selled);
        }

        // POST: selleds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            selled selled = db.selleds.Find(id);
            db.selleds.Remove(selled);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
