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
       
     
        public static void InitProgress() 
        {
            
            List<List<Progress>> progressList = new List<List<Progress>>();
            
            for (int i = 0; i < _modules.Count(); i++)
            {
                List<Models.Progress> sublist = new List<Models.Progress>();
                for (int j = 0; j < _internsTable.Count(); j++)
                {
                   
                    Progress progressInd = new Progress();
                    progressInd.intern = _internsTable[j];
                    progressInd.module = _modules[i];
                    progressInd.progress = 0;
                    //man this code could really do anything idk what this is
                    for (int k = 0; k < _modules[i].Checklist.Length; k++) {
                        //progressInd.checklistState[k] = false;
                    }
                    sublist.Add(progressInd);
                }

                _progressTable.Add(sublist);
            }
        }
        public static List<List<Models.Progress>> GetProgress()
        {
            return _progressTable;
        }

        public static void SetProgressChecklist(Intern internParam, Module moduleParam, int num, bool state)
        {
            for (int i = 0; i < _internsTable.Count(); i++)
            {
                for (int j = 0; j < _modules.Count(); j++)
                {
                    if ((_progressTable[i][j].intern.ActiveKey == internParam.ActiveKey) && (_progressTable[i][j].module.Title.Equals(moduleParam.Title)))
                    {
                        _progressTable[i][j].checklistState[num] = state;
                    }
                }
            }
        }

        public static void GetProgressChecklist(Intern internParam, Module moduleParam, int num, bool state)
        {
            for (int i = 0; i < _internsTable.Count(); i++)
            {
                for (int j = 0; j < _modules.Count(); j++)
                {
                    if ((_progressTable[i][j].intern.ActiveKey == internParam.ActiveKey) && (_progressTable[i][j].module.Title.Equals(moduleParam.Title)))
                    {
                        _progressTable[i][j].checklistState[num] = state;
                    }
                }
            }
        }

        private static List<List<Models.Progress>> _progressTable = new List<List<Progress>>();
       
     
        
        public static void SetProgress(Intern internParam, Module moduleParam, int progressParam)
        {
            for (int i = 0; i < _internsTable.Count(); i++)
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

        public static void InitModules()
        {
            var modList = new List<Module>();
            Module mod = new Module();
            mod.Title = "Development Tools";
            mod.Overview = "One of the most important tools a developer needs is their development environment. This term is used to describe the tools a developer needs to create a technical solution. Each developer has their own preferences when it comes to how these are setup and you will most likely develop your own preferences as you learn and develop. This module will walk you through our set of development tools as an introduction to the IDEs that we use on a daily basis.";
            mod.SMEs = new[] { "Zach Gay", "Ron Jones", "Craig Trulove", "Michael Buckman" };
            mod.Checklist = new[] { "Set-up Visual Studio", "Win At Life", "Purchase Gorton's Fishsticks" };
            mod.InstructionLink = "https://teams.microsoft.com/l/channel/19%3Af9d21f79034c4f6690ceed6586e73248%40thread.skype/tab%3A%3A937ecfbd-5b52-4d8c-8856-e5447c0e8f7e?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod.Rating = new[] { 10, 8, 2 };
            mod.Comments = new[,]
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
            mod2.SMEs = new[] { "George Chang", "Mike Ward", "Michael Yao", "Storm Anderson" };
            mod2.Checklist = new[]
            { "Make Fabrikam Website",
             "Do the thang",
            "Make page for each school!!!!",
            };
            mod2.InstructionLink = "https://teams.microsoft.com/l/channel/19%3A1435ed5a7d18478288473a4e72cf37f1%40thread.skype/tab%3A%3A1c021751-0d1f-494b-946e-8b79e82bc515?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod2.Rating = new[] {10, 8, 2};
            mod2.Comments = new object[,]
            {
                { "Alex", "Fork" },
                { "Henry", "I'm good at smash" },
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

        public static List<Models.Intern> _internsTable = new List<Intern>();
    
        public static void InitIntern()
        {
    
          
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
        public static List<Models.Intern> GetInterns()
        {
            return _internsTable; 
        }

        public static List<Models.Login> _LoginTable = new List<Login>();

        public static void InitLogin ()
        {
            Login henrySignIn = new Login
            {
                Username = "henry.faulkner",
                Password = "henryPass"
            };
            _LoginTable.Add(henrySignIn);
        }

        public static List<Models.Login> GetLogins()
        {
            return _LoginTable;
        }
    }

}