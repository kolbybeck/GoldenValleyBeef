using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GVB.Controllers
{
    public class HomeController : Controller
    {
        //http GET
        public ActionResult Login()
        {
            return View();
        }

        //http POST
        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(username, "admin") && (string.Equals(password, "password")))
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                return RedirectToAction("ChooseFeedlot", "User");
            }
            else if (string.Equals(username, "user") && (string.Equals(password, "password")))
            {
                return RedirectToAction("ChooseFeedlot", "User");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}