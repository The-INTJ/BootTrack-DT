using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;



namespace Boot_Track.Models
{
    
    public class Session
    {
        
        public List<Intern> interns;

        public List<List<Progress>> progress;

        public List<Module> modules = new List<Module>();

        public void GetProgress()
        {
            if (Database.GetProgress() == null)
            {
                Database.InitProgress();
            }
            else
            {
                progress = Database.GetProgress();
            }
        }

        public void GetInterns()
        {
            if (Database.GetInterns() == null)
            {
                Database.InitIntern();
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