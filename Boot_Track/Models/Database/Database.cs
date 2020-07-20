using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
         *
         * TABLES
         *  _progress -- A 3-column table: Intern / Module / Progress (int representing percentage of completion)
         *
         * OTHER
         *  Change Module.Comments to link Intern objects with comments
         */

        private static String[,] _dummyInterns =
            {
                { "Drew", "Taylor"},
                { "Kam", "Ndirangu" },
                { "Rebekah", "Williamson" },
                { "Henry", "Faulkner" },
                { "Alex", "Karadsheh" },
            };

        private static String[,] _adminTable =
            {
                { "TL", "Stephanchick" }
            };

        /// This method initializes the intern table by assigning the interns
        /// to a progress object with an associated module and progress for 
        /// each intern/module pair
        /// 
        /// prog0 prog1 prog2 prog3
        /// progMod 0
        /// progMod 1
        /// progMod 2
        ///

        
        public static void InitProgress() 
        {
            
            var progressList = new List<List<Progress>>();
            
            for (int i = 0; i < _dummyInterns.GetLength(0); i++)
            {
                
                for (int j = 0; j < _modules.Count(); j++)
                {
                    Progress progressInd = new Progress();
                    progressInd.intern = _internsTable[i];
                    progressInd.module = _modules[j];
                    progressInd.progress = 0;
                    _progressTable[i].Add(progressInd);
                }
            }
            _progressTable = progressList;

            
        }
        public static List<List<Models.Progress>> GetProgress()
        {
            return _progressTable;
        }

        private static List<List<Models.Progress>> _progressTable;
        //= InitProgress();
     
        
        public static void SetProgress(Intern internParam, Module moduleParam, int progressParam)
        {
            for (int i = 0; i < _dummyInterns.GetLength(0); i++)
            {
                for (int j = 0; j < _modules.Count(); j++)
                {
                    if ((_progressTable[i][j].intern.ActiveKey == internParam.ActiveKey) && (_progressTable[i][j].module.Title.Equals(moduleParam.Title)))
                    {
                        _progressTable[i][j].progress = progressParam;
                    }
                }
            }
        }

        /// This is a method that creates the module tables
        /// and populates it with the module values, but might have to
        /// be hard coded
        /// Sets module paramaters
        /// _modules just holds the list of modules

        private static List<Models.Module> _modules = new List<Module>();
        //= GetModules();

        public static void InitModules()
        {
            var modList = new List<Module>();
            Module mod = new Module();
            mod.Title = "Development Tools";
            mod.Overview = "One of the most important tools a developer needs is their development environment. This term is used to describe the tools a developer needs to create a technical solution. Each developer has their own preferences when it comes to how these are setup and you will most likely develop your own preferences as you learn and develop. This module will walk you through our set of development tools as an introduction to the IDEs that we use on a daily basis.";
            mod.SMEs = new []{ "Zach Gay", "Ron Jones", "Craig Trulove", "Michael Buckman"};
            mod.Checklist = new []{ "Set-up Visual Studio", "Win At Life", "Purchase Gorton's Fishsticks"};
            mod.InstructionLink = "https://teams.microsoft.com/l/channel/19%3Af9d21f79034c4f6690ceed6586e73248%40thread.skype/tab%3A%3A937ecfbd-5b52-4d8c-8856-e5447c0e8f7e?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod.Rating = new []{ 10, 8, 2};
            mod.Comments = new [,]
                { 
                    { "Kam" , "YEET"}, 
                    { "Drew", "VS CODE IS BETTER"}, 
                };
            mod.completionDate = new DateTime(2020, 7, 17);
            _modules.Add(mod);

            // Second module hardcode
            Module mod2 = new Module();
            mod2.Title = "HTML and CSS 101";
            mod2.Overview = "HTML is the most basic building block of the Web. \n CSS is used to style and lay out web pages. \n The Flexbox Layout aims at providing a more efficient way to lay out, align and distribute space among items in a container, even when their size is unknown and/or dynamic. \n Media query is a CSS technique that made it possible to define different style rules for different media types.";
            mod2.SMEs = new[] {"George Chang", "Mike Ward", "Michael Yao", "Storm Anderson"};
            mod2.Checklist = new[]{ "Make Fabrikam Website", "Do the thang", "Make page for each school!!!!" };
            mod2.InstructionLink = "https://teams.microsoft.com/l/channel/19%3A1435ed5a7d18478288473a4e72cf37f1%40thread.skype/tab%3A%3A1c021751-0d1f-494b-946e-8b79e82bc515?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod2.Rating = new[] {10, 8, 2};
            mod2.Comments = new object[,]
            {
                { "Alex", "Fork" },
                { "Henry", "I suck at smash" },
            };
            _modules.Add(mod2);

        }

        public static List<Models.Module> GetModules()
        {
            return _modules;
        }

        /// This is a method that creates the intern table
        /// and populates it with the intern values from _dummyinterns
        /// Sets total intern progress to 0, and gives an active key
        /// _internsTable just holds the return value of .GetIntern()

        public static List<Models.Intern> _internsTable;
        //= GetIntern();
        public static void InitIntern()
        {
            //var internList = new List<Intern>();
          
            for (int i = 0; i<_dummyInterns.GetLength(0); i++)
            {
                //Console.WriteLine(_dummyInterns.GetLength(0));
                Intern intern = new Intern();
                intern.FirstName = _dummyInterns[i, 0];
                intern.LastName = _dummyInterns[i, 1];
                intern.TotalInternProgress = 0;
                intern.ActiveKey = i;
                _internsTable.Add(intern);
            }

           // _internsTable = internList;
            
        }
        public static List<Intern> GetInterns()
        {
            return _internsTable;
        }
    }

}