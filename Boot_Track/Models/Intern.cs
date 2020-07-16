using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Boot_Track.Models
{
    public class Intern
    {

        public string FirstName { get; set;}

        public string LastName { get; set; }

        public int  Progress { get; set; }

        public int ActiveKey { get; set; }


    
    }
}