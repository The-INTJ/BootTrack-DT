using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boot_Track.Models;

namespace Boot_Track.Controllers
{
    public class ModulesController : Controller
    {
        // GET: Modules
        [Route("Modules/ModulePage/{ModuleTitle}")]
        public ActionResult ModulePage(string ModuleTitle)
        {
            if (HttpContext.Request.Cookies["IsLoggedIn"] == null)
            {
                return Redirect("/Login/Index");
            }

            var sesh = new Session();
            sesh.GetModules();
            foreach (var module in sesh.modules)
            {
                if (module.Title == ModuleTitle)
                {
                    return View(module);
                }
            }
            return View(sesh.modules[0]);
        }
    }
}