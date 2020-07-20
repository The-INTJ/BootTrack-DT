using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boot_Track.Models
{
    public class Email
    {
        public string subject { get; set; }
        public string message { get; set; }
        public string receiver { get; set; }
    }
}