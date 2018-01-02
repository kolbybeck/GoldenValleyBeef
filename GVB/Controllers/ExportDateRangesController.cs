using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GVB.DAL;
using GVB.Models;

namespace GVB.Controllers
{
    public class ExportDateRangesController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        // GET: ExportDateRanges
        public ActionResult Index()
        {
            return View(db.ExportDateRange.ToList());
        }

        // GET: ExportDateRanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportDateRange exportDateRange = db.ExportDateRange.Find(id);
            if (exportDateRange == null)
            {
                return HttpNotFound();
            }
            return View(exportDateRange);
        }

        // GET: ExportDateRanges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExportDateRanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExportDateRangeID,StartDate,EndDate")] ExportDateRange exportDateRange)
        {
            if (ModelState.IsValid)
            {
                db.ExportDateRange.Add(exportDateRange);
                db.SaveChanges();
                return RedirectToAction("Reports", "User");
            }

            return View("Reports", "User");
        }

        // GET: ExportDateRanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportDateRange exportDateRange = db.ExportDateRange.Find(id);
            if (exportDateRange == null)
            {
                return HttpNotFound();
            }
            return View(exportDateRange);
        }

        // POST: ExportDateRanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExportDateRangeID,StartDate,EndDate")] ExportDateRange exportDateRange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exportDateRange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exportDateRange);
        }

        // GET: ExportDateRanges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportDateRange exportDateRange = db.ExportDateRange.Find(id);
            if (exportDateRange == null)
            {
                return HttpNotFound();
            }
            return View(exportDateRange);
        }

        // POST: ExportDateRanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExportDateRange exportDateRange = db.ExportDateRange.Find(id);
            db.ExportDateRange.Remove(exportDateRange);
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
