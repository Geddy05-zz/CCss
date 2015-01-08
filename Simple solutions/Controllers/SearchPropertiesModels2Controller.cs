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
    public class SearchPropertiesModels2Controller : Controller
    {
        private AdminContext db = new AdminContext();

        // GET: SearchPropertiesModels2
        public ActionResult Index()
        {
            return View(db.SearchPropertiesModels.ToList());
        }

        // GET: SearchPropertiesModels2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchPropertiesModel searchPropertiesModel = db.SearchPropertiesModels.Find(id);
            if (searchPropertiesModel == null)
            {
                return HttpNotFound();
            }
            return View(searchPropertiesModel);
        }

        // GET: SearchPropertiesModels2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchPropertiesModels2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,processorType,processorClockSpeed,processorcores,memorySlots,memorySpeed,graphicCardSpeed,graphicCardType,hardDrivetype,hardDriveCapacity,opticalDriveCategory,systemUnitFormfactor")] SearchPropertiesModel searchPropertiesModel)
        {
            if (ModelState.IsValid)
            {
                db.SearchPropertiesModels.Add(searchPropertiesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(searchPropertiesModel);
        }

        // GET: SearchPropertiesModels2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchPropertiesModel searchPropertiesModel = db.SearchPropertiesModels.Find(id);
            if (searchPropertiesModel == null)
            {
                return HttpNotFound();
            }
            return View(searchPropertiesModel);
        }

        // POST: SearchPropertiesModels2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,processorType,processorClockSpeed,processorcores,memorySlots,memorySpeed,graphicCardSpeed,graphicCardType,hardDrivetype,hardDriveCapacity,opticalDriveCategory,systemUnitFormfactor")] SearchPropertiesModel searchPropertiesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(searchPropertiesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(searchPropertiesModel);
        }

        // GET: SearchPropertiesModels2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchPropertiesModel searchPropertiesModel = db.SearchPropertiesModels.Find(id);
            if (searchPropertiesModel == null)
            {
                return HttpNotFound();
            }
            return View(searchPropertiesModel);
        }

        // POST: SearchPropertiesModels2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SearchPropertiesModel searchPropertiesModel = db.SearchPropertiesModels.Find(id);
            db.SearchPropertiesModels.Remove(searchPropertiesModel);
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
