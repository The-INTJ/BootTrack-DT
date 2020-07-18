﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boot_Track.Models;

namespace Boot_Track.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index

        // Logic for parsing session object, null check (return error if failed), return view with session object
        public ActionResult Index()
        {

            var sesh = new Session();
            sesh.GetModules();
            return View(sesh);
        }
    }
}