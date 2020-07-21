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
        Session sesh = new Session();

        // GET: Modules
        [Route("Modules/ModulePage/{ModuleTitle}")]
        public ActionResult ModulePage(string ModuleTitle)
        {
            if (HttpContext.Request.Cookies["IsLoggedIn"] == null)
            {
                return Redirect("/Login/Index");
            }
            
            sesh.GetModules();
            sesh.GetProgress();
            foreach (var module in sesh.modules)
            {
                if (module.Title == ModuleTitle)
                {
                    sesh.CurrModule = module;
                    return View(sesh);
                }
            }
            return View(sesh);
        }

        [Route("Modules/ModulePage/{ModuleTitle}/{num}")]
        public ActionResult ChangeCheckList(string ModuleTitle, string num)
        {
            int i = Int32.Parse(num.Substring(0, num.Length-1));
            Debug.WriteLine(i);
            Intern intern = new Intern();

            foreach (var intrn in sesh.interns)
            {
                if (Request.Cookies["Username"].Value == (intrn.FirstName + "." + intrn.LastName).ToLower())
                {
                    intern = intrn;
                }
            }

            sesh.SetProgressChecklist(intern, sesh.CurrModule, i, sesh.GetProgress(intern, sesh.CurrModule).checklistState[i]);

            return Redirect($"/Modules/ModulePage/{ModuleTitle}");
        }
    }
}