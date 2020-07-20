using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Boot_Track.Models;
using System.Diagnostics;

namespace Boot_Track.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index

        // Logic for parsing session object, null check (return error if failed), return view with session object
        public ActionResult Index()
        {
            if (HttpContext.Request.Cookies["IsLoggedIn"] == null)
            {
                return Redirect("/Login/Index");
            }

            var sesh = new Session();
            sesh.GetModules();
            sesh.GetInterns();
            sesh.GetProgress();

            return View(sesh);
        }

        public ActionResult AdminIndex()
        {
            var sesh = new Session();
            sesh.GetModules();
            sesh.GetInterns();
            sesh.GetProgress();

            return View(sesh);
        }

        public ActionResult SendEmail()
        {
            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 25,
                UseDefaultCredentials = false, // This require to be before setting Credentials property
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential("henry.faulkner@perficient.com", "HenLouFau27"), // you must give a full email address for authentication 
                TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                EnableSsl = true // Set to avoid secure connection exception
            })
            {

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("henry.faulkner@perficient.com"), // sender must be a full email address
                    Subject = "Asp Net Mail Test",
                    IsBodyHtml = true,
                    Body = "<h1>Hello World</h1>",
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                };
                //var toAddresses = recipients.Split(',');
                //foreach (var to in toAddresses)
                //{
                //    message.To.Add(to.Trim());
                //}
                message.To.Add("henry.faulkner@perficient.com");

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return Redirect("/Modules/ModulePage");
        }
    }
}