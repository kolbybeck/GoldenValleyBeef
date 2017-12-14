using GVB.DAL;
using GVB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GVB.Controllers
{
    public class HelperController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        public static int employeeAuthID;

        public static int SetEmployeeAuthID(Employee employee)
        {
            employeeAuthID = employee.RoleID;

            return employeeAuthID;
        }

        public static int GetEmployeeAuthID()
        {
            return employeeAuthID;
        }
    }
}