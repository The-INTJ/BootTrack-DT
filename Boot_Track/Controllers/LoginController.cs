using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boot_Track.Models;

namespace Boot_Track.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TryLogin(Login login)
        {
            // Data checks

            return View("Index");
        }
    }
}