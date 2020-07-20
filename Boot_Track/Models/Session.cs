using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;



namespace Boot_Track.Models
{
    
    public class Session
    {
        
        public List<Intern> interns = new List<Intern>();

        public List<List<Progress>> progress = new List<List<Progress>>();

        public List<Module> modules = new List<Module>();

        public Email email = new Email();

        public void GetProgress()
        {
            if (!Database.GetProgress().Any())
            {
                Database.InitProgress();
                progress = Database.GetProgress();
            }
            else
            {
                progress = Database.GetProgress();
            }
        }

        public void GetInterns()
        {
            if (!Database.GetInterns().Any())
            {
                Database.InitIntern();
                interns = Database.GetInterns();
            }
            else
            {
                interns = Database.GetInterns();
            }
        }

        public void GetModules()
        {
            if (!Database.GetModules().Any())
            {
                Database.InitModules();
                modules = Database.GetModules();
            }
            else
            {
                //Database.InitModules();
                modules = Database.GetModules();
            }
        }
    }
}