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
    }
}