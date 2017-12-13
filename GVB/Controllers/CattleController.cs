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
    [Authorize]
    public class CattleController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        // GET: Cattle
        public ActionResult Index()
        {
            var cattle = db.Cattle.Include(c => c.Dairy).Include(c => c.Feedlot);
            return View(cattle.ToList());
        }

        // GET: Cattle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cattle cattle = db.Cattle.Find(id);
            if (cattle == null)
            {
                return HttpNotFound();
            }
            return View(cattle);
        }

        // GET: Cattle/Create
        public ActionResult Create()
        {
            ViewBag.DairyID = new SelectList(db.Dairy, "DairyID", "dName");
            ViewBag.feedlotID = new SelectList(db.Feedlot, "FeedlotID", "fName");
            return View();
        }

        // POST: Cattle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cattleID,cattleNumber,DairyID,feedlotID,DateRecieved,ShippedDate")] Cattle cattle)
        {
            if (ModelState.IsValid)
            {
                db.Cattle.Add(cattle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DairyID = new SelectList(db.Dairy, "dairyID", "dName", cattle.DairyID);
            ViewBag.feedlotID = new SelectList(db.Feedlot, "feedlotID", "fName", cattle.FeedlotID);
            return View(cattle);
        }

        // GET: Cattle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cattle cattle = db.Cattle.Find(id);
            if (cattle == null)
            {
                return HttpNotFound();
            }
            ViewBag.DairyID = new SelectList(db.Dairy, "dairyID", "dName", cattle.DairyID);
            ViewBag.feedlotID = new SelectList(db.Feedlot, "feedlotID", "fName", cattle.FeedlotID);
            return View(cattle);
        }

        // POST: Cattle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cattleID,cattleNumber,DairyID,feedlotID,DateRecieved,ShippedDate")] Cattle cattle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cattle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DairyID = new SelectList(db.Dairy, "DairyID", "dName", cattle.DairyID);
            ViewBag.feedlotID = new SelectList(db.Feedlot, "feedlotID", "fName", cattle.FeedlotID);
            return View(cattle);
        }

        // GET: Cattle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cattle cattle = db.Cattle.Find(id);
            if (cattle == null)
            {
                return HttpNotFound();
            }
            return View(cattle);
        }

        // POST: Cattle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cattle cattle = db.Cattle.Find(id);
            db.Cattle.Remove(cattle);
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