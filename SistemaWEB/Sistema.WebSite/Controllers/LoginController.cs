using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sistema.WebSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usr, string pwd)
        {
            if (usr == "ld" && pwd == "ld")
            {
                FormsAuthentication.SetAuthCookie("ld", false);
                return RedirectToAction("Index", "Principal");
            }
            return View();
        }
    }
}