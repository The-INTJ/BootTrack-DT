using Boot_Track.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boot_Track.Controllers
{
    public class InternController : Controller
    {
        // GET: Intern
        public ActionResult InternTable(Session obj)
        {
        
            return View(obj);
        }
    }
}