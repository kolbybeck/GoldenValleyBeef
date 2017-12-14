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
                            "SELECT RoleID " +
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


        //[Authorize(Roles = "User,Administrator")]
        public ActionResult ChooseFeedlot()
        {
            var feedlot = db.Feedlot;
            return View(feedlot.ToList());
        }

        //[Authorize(Roles ="Administrator")]
        public ActionResult Admin()
        {
            return View();
        }

        //[Authorize(Roles = "Administrator")]
        public ActionResult Advanced()
        {
            return View();
        }

        //[Authorize(Roles = "Administrator")]
        public ActionResult Reports()
        {
            return View();
        }
    }
}