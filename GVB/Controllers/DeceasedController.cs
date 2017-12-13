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
    public class DeceasedController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        // GET: Deceaseds
        public ActionResult Index()
        {
            var deceased = db.Deceased.Include(d => d.Dairy).Include(d => d.Employee).Include(d => d.Feedlot);
            return View(deceased.ToList());
        }

        // GET: Deceaseds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deceased deceased = db.Deceased.Find(id);
            if (deceased == null)
            {
                return HttpNotFound();
            }
            return View(deceased);
        }

        // GET: Deceaseds/Create
        public ActionResult Create(int? feedlotID, string feedlotName)
        {
            ViewBag.DairyID = new SelectList(db.Dairy, "dairyID", "dName");
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmpFname");
            ViewBag.FeedlotID = new SelectList(db.Feedlot, "FeedlotId", "fName");
            ViewBag.Navigation = feedlotID;
            return View();
        }

        //public ActionResult ConfirmCow(int? feedlotNum, string dName, string CattleNumber)
        //{
        //    if( feedlotNum != null)
        //    {
        //        IEnumerable<Cattle> cattle =
        //        db.Database.SqlQuery<Cattle>("SELECT Cattle.CattleID, Cattle.CattleNumber, Cattle.DairyID, Cattle.FeedlotID, " +
        //        "Cattle.CattleTypeID " +
        //        "FROM Cattle INNER JOIN Dairy ON Cattle.DairyID = Dairy.DairyID " +
        //        "WHERE Cattle.FeedlotID = " + feedlotNum + " AND Dairy.dName = " + dName +
        //        " AND Cattle.CattleNumber = " + CattleNumber);

        //        return View(Cattle.FirstOrDefault());
        //    }
        //    else
        //    {
        //        return RedirectToAction("ChooseFeedlot", "User");
        //    }

        //}

        // POST: Deceaseds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CattleNumber,DeceasedDate,DairyID,FeedlotID,EmployeeID")] Deceased deceased)
        {
            if (ModelState.IsValid)
            {
                db.Deceased.Add(deceased);
                db.SaveChanges();
                return RedirectToAction("Create", "Deceased", new { feedlotID = deceased.FeedlotID });
            }

            ViewBag.DairyID = new SelectList(db.Dairy, "dairyID", "dName", deceased.DairyID);
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmpFname", deceased.EmployeeID);
            ViewBag.FeedlotID = new SelectList(db.Feedlot, "feedlotID", "fName", deceased.FeedlotID);
            return View(deceased);
        }

        // GET: Deceaseds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deceased deceased = db.Deceased.Find(id);
            if (deceased == null)
            {
                return HttpNotFound();
            }
            ViewBag.DairyID = new SelectList(db.Dairy, "dairyID", "dName", deceased.DairyID);
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmpFname", deceased.EmployeeID);
            ViewBag.FeedlotID = new SelectList(db.Feedlot, "feedlotID", "fName", deceased.FeedlotID);
            return View(deceased);
        }

        // POST: Deceaseds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CattleID,CattleNumber,DeceasedDate,DairyID,FeedlotID,EmployeeID")] Deceased deceased)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deceased).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DairyID = new SelectList(db.Dairy, "dairyID", "dName", deceased.DairyID);
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmpFname", deceased.EmployeeID);
            ViewBag.FeedlotID = new SelectList(db.Feedlot, "feedlotID", "fName", deceased.FeedlotID);
            return View(deceased);
        }

        // GET: Deceaseds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deceased deceased = db.Deceased.Find(id);
            if (deceased == null)
            {
                return HttpNotFound();
            }
            return View(deceased);
        }

        // POST: Deceaseds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deceased deceased = db.Deceased.Find(id);
            db.Deceased.Remove(deceased);
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