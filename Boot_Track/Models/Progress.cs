using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boot_Track.Models
{
    public class Progress
    {
      
        public Intern intern { get; set; }

        public Module module { get; set; }

        public int progress { get; set; }

        public List<bool> checklistState { get; set; }

        public string moduleProgress { get; set; }
    }
}