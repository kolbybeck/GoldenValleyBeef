using GVB.Models;
using GVB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GVB.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        public Employee myEmployee = new GVB.Models.Employee();

        public Employee GetEmployee()
        {
            if (User.Identity.IsAuthenticated)
            {
                string myEmail = User.Identity.Name;
                myEmployee = db.Employee.SqlQuery(
                            "SELECT * " +
                            "From Employee " +
                            "where Employee.EmpEmail = '" + myEmail + "'"
                            ).FirstOrDefault();
                if (myEmployee == null)
                {
                    myEmployee.EmployeeID = 2;
                    return myEmployee;
                }
                else
                {
                    return myEmployee;
                }
            }
            else
            {
                myEmployee.EmployeeID = 2;
                return myEmployee;
            }
        }


        //[Authorize(Roles = "2, 1")]
        public ActionResult ChooseFeedlot()
        {
            var feedlot = db.Feedlot;
           
            return View(feedlot.ToList());
        }

        //[Authorize(Roles ="1")]
        public ActionResult Admin()
        {
            return View();
        }

        //[Authorize(Roles = "1")]
        public ActionResult Advanced()
        {
            return View();
        }

        //[Authorize(Roles = "1")]
        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult ClearData()
        {
            return View();
        }


        //FIX THIS
        // POST: Deceaseds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteAll(int id)
        //{
        //    IEnumerable<GVB.Models.Deceased>

        //    var ClearData = db.Deceased.Where(a => a.CattleID == id).ToList();
        //    foreach (var Cow in ClearData)
        //        db.ClearData.Remove(Cow);
        //    db.SaveChanges();

        //    db.Deceased.Remove();
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}