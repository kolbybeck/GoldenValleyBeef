using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GVB.DAL;

namespace GVB.Models
{
    public class DairiesController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        // GET: Dairies
        public ActionResult Index()
        {
            var dairy = db.Dairy.Include(d => d.State);
            return View(dairy.ToList());
        }

        // GET: Dairies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dairy dairy = db.Dairy.Find(id);
            if (dairy == null)
            {
                return HttpNotFound();
            }
            return View(dairy);
        }

        // GET: Dairies/Create
        public ActionResult Create()
        {
            ViewBag.StateID = new SelectList(db.State, "StateID", "StateName");
            return View();
        }

        // POST: Dairies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dairyID,dName,dAddress,dCity,StateID,dZip,dPhone")] Dairy dairy)
        {
            if (ModelState.IsValid)
            {
                db.Dairy.Add(dairy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateID = new SelectList(db.State, "StateID", "StateName", dairy.StateID);
            return View(dairy);
        }

        // GET: Dairies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dairy dairy = db.Dairy.Find(id);
            if (dairy == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.State, "StateID", "StateName", dairy.StateID);
            return View(dairy);
        }

        // POST: Dairies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dairyID,dName,dAddress,dCity,StateID,dZip,dPhone")] Dairy dairy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dairy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateID = new SelectList(db.State, "StateID", "StateName", dairy.StateID);
            return View(dairy);
        }

        // GET: Dairies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dairy dairy = db.Dairy.Find(id);
            if (dairy == null)
            {
                return HttpNotFound();
            }
            return View(dairy);
        }

        // POST: Dairies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dairy dairy = db.Dairy.Find(id);
            db.Dairy.Remove(dairy);
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