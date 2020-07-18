using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boot_Track.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index

        // Logic for parsing session object, null check (return error if failed), return view with session object
        public ActionResult Index()
        {
            return View();
        }
    }
}