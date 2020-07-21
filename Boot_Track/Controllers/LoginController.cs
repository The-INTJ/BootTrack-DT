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
            HttpContext.Response.Cookies.Remove("IsLoggedIn");

            return View();
        }

        public ActionResult TryLogin(Login login)
        {
            // Data checks
            var sesh = new Session();
            sesh.GetLogins();
            foreach (var user in sesh.logins)
            {
                if (user.Username == login.Username && user.Password == login.Password)
                {
                    HttpCookie loggedinCookie = new HttpCookie("IsLoggedIn");
                    loggedinCookie.Value = "True";
                    HttpContext.Response.Cookies.Add(loggedinCookie);

                    HttpCookie userCookie = new HttpCookie("Username");
                    userCookie.Value = user.Username;
                    HttpContext.Response.Cookies.Add(userCookie);

                    HttpCookie passCookie = new HttpCookie("Password");
                    passCookie.Value = user.Password;
                    HttpContext.Response.Cookies.Add(passCookie);

                    HttpCookie adminCookie = new HttpCookie("Admin");
                    if (user.IsAdmin == true)
                        adminCookie.Value = "True";
                    HttpContext.Response.Cookies.Add(adminCookie);
                       

                    return Redirect("/Index/Index");
                }
            }

            return View("Index");
        }
    }
}