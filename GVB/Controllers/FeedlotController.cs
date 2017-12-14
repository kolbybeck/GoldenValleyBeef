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
    public class FeedlotController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        // GET: Feedlots
        public ActionResult Index()
        {
            return View(db.Feedlot.ToList());
        }

        public ActionResult ChooseFeedlot()
        {
            var feedlot = db.Feedlot;
            return View(feedlot.ToList());
        }

        // GET: Feedlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedlot feedlot = db.Feedlot.Find(id);
            if (feedlot == null)
            {
                return HttpNotFound();
            }
            return View(feedlot);
        }

        // GET: Feedlots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedlots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "feedlotID,fName")] Feedlot feedlot)
        {
            if (ModelState.IsValid)
            {
                db.Feedlot.Add(feedlot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedlot);
        }

        // GET: Feedlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedlot feedlot = db.Feedlot.Find(id);
            if (feedlot == null)
            {
                return HttpNotFound();
            }
            return View(feedlot);
        }

        // POST: Feedlots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "feedlotID,fName")] Feedlot feedlot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedlot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedlot);
        }

        // GET: Feedlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedlot feedlot = db.Feedlot.Find(id);
            if (feedlot == null)
            {
                return HttpNotFound();
            }
            return View(feedlot);
        }

        // POST: Feedlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedlot feedlot = db.Feedlot.Find(id);
            db.Feedlot.Remove(feedlot);
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