using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boot_Track.Models;

namespace Boot_Track.Controllers
{
    public class ModulesController : Controller
    {
        // GET: Modules
        public ActionResult ModulePage(String ModuleTitle)
        {
            var sesh = new Session();
            sesh.GetModules();
            foreach (var module in sesh.modules)
            {
                if (module.Title != ModuleTitle)
                {
                   
                    return View(module);
                }
            }
            return View(sesh.modules[0]);
        }
    }
}