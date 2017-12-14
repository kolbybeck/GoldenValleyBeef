using GVB.Models;
using GVB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GVB.Controllers
{
    public class UserController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

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