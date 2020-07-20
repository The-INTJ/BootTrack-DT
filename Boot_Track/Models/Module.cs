using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boot_Track.Models
{
    public class Module
    {

        public Module() { }

        public string Title { get; set; }

        public string Overview { get; set; }

        public string [] SMEs { get; set; }

        public string [] Checklist { get; set; }

        public string InstructionLink { get; set; }

        public int [] Rating { get; set; }

        public object [,] Comments { get; set; }

        public DateTime completionDate { get; set; }


    }
}