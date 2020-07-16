using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boot_Track.Models
{
    public static class Database
    {

        // TODO
        /*
         * MODELS
         * Create Interns model, change @_internTable to be an array of Interns
         *  You can follow the current pattern I laid out with _modules
         *  FYI, the Intern model will eventually store a unique id key that maps them
         *  to their Active Directory. You can store a fake one for now that makes searching for
         *  them easier.
         *
         * METHODS
         *  GetInterns -- returns all interns as an array of intern objects
         *
         *  CreateProgress -- Initializes the _progress table
         *      Do NOT hardcode the progress table, it would take you far too long.
         *      This method takes all Intern/Module pairs and puts an entry in the table with progress
         *      set to 0.
         *
         *  SetProgress -- Takes an intern, module, and int as a param. It will find the entry in the
         *  progress table and update it. Make sure to perform error checking, wouldn't want to try
         *  this before the table has been created.
         *
         * TABLES
         *  _progress -- A 3-column table: Intern / Module / Progress (int representing percentage of completion)
         *
         */

        private static String[,] _internTable =
            {
                { "Drew", "Taylor" },
                { "Kam", "Ndirango" },
                { "Rebekah", "Williamson" },
                { "Henry", "Faulkner" },
                { "Alex", "Karadsheh" },
            };

        private static String[,] _adminTable =
            {
                { "TL", "Stephanchick" }
            };

        private static List<Models.Module> _modules = GetModules();

        private static List<Models.Module> GetModules()
        {
            var modList = new List<Module>();
            Module mod = new Module();
            mod.Title = "Development Tools";
            mod.Overview = "One of the most important tools a developer needs is their development environment. This term is used to describe the tools a developer needs to create a technical solution. Each developer has their own preferences when it comes to how these are setup and you will most likely develop your own preferences as you learn and develop. This module will walk you through our set of development tools as an introduction to the IDEs that we use on a daily basis.";
            mod.SMEs = new []{ "Zach Gay", "Ron Jones", "Craig Trulove", "Michael Buckman"};
            mod.Checklist = new []{ "Set-up Visual Studio", "Win At Life", "Purchase Gorton's Fishsticks"};
            mod.InstructionLink = "https://teams.microsoft.com/l/channel/19%3Af9d21f79034c4f6690ceed6586e73248%40thread.skype/tab%3A%3A937ecfbd-5b52-4d8c-8856-e5447c0e8f7e?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod.Rating = new []{ 10, 8, 2};
            mod.Comments = { { "Kam", "YEET"}, { "Drew", "VS CODE IS BETTER"} };
            modList.Add(mod);
            return modList;
        }

    }

}