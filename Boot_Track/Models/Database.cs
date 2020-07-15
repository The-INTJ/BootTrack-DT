using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boot_Track.Models
{
    public static class Database
    {

        private static String[,] Intern_Table =
            {
                { "Drew", "Taylor" },
                { "Kam", "Ndirango" },
                { "Rebekah", "Williamson" },
                { "Henry", "Faulkner" },
                { "Alex", "Karadsheh" },
            };

        private static String[,] Admin_Table =
            {
                { "TL", "Stephanchick" }
            };

        private static List<Models.Module> Modules = GetModules();

        private static List<Models.Module> GetModules()
        {
            var modList = new List<Module>();
            Module mod = new Module();
            mod.Title = "Development Tools";
            mod.Overview = "One of the most important tools a developer needs is their development environment. This term is used to describe the tools a developer needs to create a technical solution. Each developer has their own preferences when it comes to how these are setup and you will most likely develop your own preferences as you learn and develop. This module will walk you through our set of development tools as an introduction to the IDEs that we use on a daily basis.";
            mod.SMEs = { "Zach Gay", "Ron Jones", "Craig Trulove", "Michael Buckman"};
            mod.Checklist { "Set-up Visual Studio", "Win At Life", "Purchase Gorton's Fishsticks"};
            mod.InstructionLink = "https://teams.microsoft.com/l/channel/19%3Af9d21f79034c4f6690ceed6586e73248%40thread.skype/tab%3A%3A937ecfbd-5b52-4d8c-8856-e5447c0e8f7e?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod.Rating = { 10, 8, 2};
            mod.Comments = { { "Kam", "YEET"}, { "Drew", "VS CODE IS BETTER"} };
            modList.Add(mod);
            return modList;
        }

    }

}