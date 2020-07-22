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
                { "David", "Davenport" },
                { "Grayson", "Harden" },
                { "Mary Claire", "Freese" },
                { "Kallie", "Cothran" },
                { "Kerry", "Bethea" },
                { "Bela", "Colmenares" },
                { "Jeremy", "Balemala" },
                { "Eric", "Cho" },
                { "David", "Hwang" }
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
                   
                    Progress progress = new Progress();
                    progress.intern = _internsTable[j];
                    progress.module = _modules[i];
                    progress.progress = 0;
                    progress.checklistState = new List<bool>();
                    progress.moduleProgress = ""; //initialize to not started
                    //man this code could really do anything idk what this is
                    for (int k = 0; k < _modules[i].Checklist.Length; k++) {    
                        progress.checklistState.Add(false); //initialize all checkboxes to false
                    }
                    sublist.Add(progress);
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
            for (int i = 0; i < _modules.Count(); i++)
            {
                for (int j = 0; j < _internsTable.Count(); j++)
                {
                    if ((_progressTable[i][j].intern.ActiveKey == internParam.ActiveKey) && (_progressTable[i][j].module.Title.Equals(moduleParam.Title)))
                    {
                        _progressTable[i][j].checklistState[num] = state;
                    }
                }
            }
        }

        public static bool GetProgressChecklist(Intern internParam, Module moduleParam, int num)
        {
            for (int i = 0; i < _modules.Count(); i++)
            {
                for (int j = 0; j < _internsTable.Count(); j++)
                {
                    if ((_progressTable[i][j].intern.ActiveKey == internParam.ActiveKey) && (_progressTable[i][j].module.Title.Equals(moduleParam.Title)))
                    {
                        return _progressTable[i][j].checklistState[num];
                    }
                  
                }
                
            }
            return false;
        }

        private static List<List<Models.Progress>> _progressTable = new List<List<Progress>>();
       
     
        
        public static void SetProgress(Intern internParam, Module moduleParam, int progressParam)
        {
            for (int i = 0; i < _modules.Count(); i++)
            {
                for (int j = 0; j < _internsTable.Count(); j++)
                {
                    if ((_progressTable[i][j].intern.ActiveKey == internParam.ActiveKey) && (_progressTable[i][j].module.Title.Equals(moduleParam.Title)))
                    {
                        _progressTable[i][j].progress = progressParam;
                    }
                }
            }
        }

        public static Progress GetProgress(Intern internParam, Module moduleParam)
        {
            for (int i = 0; i < _modules.Count(); i++)
            {
                for (int j = 0; j < _internsTable.Count(); j++)
                {
                    if ((_progressTable[i][j].intern.ActiveKey == internParam.ActiveKey) && (_progressTable[i][j].module.Title.Equals(moduleParam.Title)))
                    {
                        return _progressTable[i][j];
                    }
                }
            }
            return _progressTable[0][0];
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
            mod.Checklist = new[] { "Set-up Visual Studio", "Acquire MSDN license", "Set-up OneNote" };
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
            { "HTML & CSS+",
            "FlexBox",
             "Chrome Debugging Tools",
            "Make Fabrikam Website",
            };
            mod2.InstructionLink = "https://teams.microsoft.com/l/channel/19%3A1435ed5a7d18478288473a4e72cf37f1%40thread.skype/tab%3A%3A1c021751-0d1f-494b-946e-8b79e82bc515?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod2.Rating = new[] {10, 8, 2};
            mod2.Comments = new object[,]
            {
                { "Alex", "Fork" },
                { "Henry", "I'm good at smash" },
            };
            _modules.Add(mod2);

            Module mod3 = new Module();
            mod3.Title = "JavaScript 101";
            mod3.Overview = "JavaScript is probably the most ubiquitous programming language today. It is most widely used on web pages to augment the user experience through animations and small UI tweaks. More and more JavaScript is being used as an application development language as in the case of sing page apps (SPAs) or node.js a server side version of JavaScript. Today it is possible to write your whole application using JavaScript.";
            mod3.SMEs = new[] { "Zach Gay", "Nick Sturdivant", "Ravind Budhiraja", "Michael Buckman" };
            mod3.Checklist = new[] { "Intro to JavaScript", "Introduction to jQuery", "Add Some Koolnesss to the Fabrikam site", "Typescript" };
            mod3.InstructionLink = "https://teams.microsoft.com/l/channel/19%3Af9d21f79034c4f6690ceed6586e73248%40thread.skype/tab%3A%3A937ecfbd-5b52-4d8c-8856-e5447c0e8f7e?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod3.Rating = new[] { 10, 8, 2 };
            mod3.Comments = new[,]
                {
                    { "Kam" , "YEET"},
                    { "Drew", "VS CODE IS BETTER"},
                };
            mod3.completionDate = new DateTime(2020, 7, 17);
            _modules.Add(mod3);

            Module mod4 = new Module();
            mod4.Title = "C-Sharp 101";
            mod4.Overview = "C# is Microsoft’s primary managed programming language, and is the language used most often in our server-side development projects.  It is a foundation for ASP.NET and SharePoint development.  This module is intended to give you an introduction to using the language for basic development tasks.";
            mod4.SMEs = new[] { "George Chang", "Mike Ward", "Michael Yao", "Storm Anderson" };
            mod4.Checklist = new[]
            { "Make Fabrikam Website",
             "Do the thang",
            "Make page for each school!!!!",
            };
            mod4.InstructionLink = "https://teams.microsoft.com/l/channel/19%3A1435ed5a7d18478288473a4e72cf37f1%40thread.skype/tab%3A%3A1c021751-0d1f-494b-946e-8b79e82bc515?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod4.Rating = new[] { 10, 8, 2 };
            mod4.Comments = new object[,]
            {
                { "Alex", "Fork" },
                { "Henry", "I'm good at smash" },
            };
            _modules.Add(mod4);

            Module mod5 = new Module();
            mod5.Title = "SQL 101";
            mod5.Overview = "SQL is a special-purpose programming language designed for managing data held in a relational database management system (RDBMS). SQL consists of a data definition language and data manipulation language. The scope of SQL includes data insert, query, update and delete, schema creation and modification, and data access control. This module is intended to give you an introduction to using the language for simple development tasks.";
            mod5.SMEs = new[] { "George Chang", "Mike Ward", "Michael Yao", "Storm Anderson" };
            mod5.Checklist = new[]
            { "Make Fabrikam Website",
             "Do the thang",
            "Make page for each school!!!!",
            };
            mod5.InstructionLink = "https://teams.microsoft.com/l/channel/19%3A1435ed5a7d18478288473a4e72cf37f1%40thread.skype/tab%3A%3A1c021751-0d1f-494b-946e-8b79e82bc515?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod5.Rating = new[] { 10, 8, 2 };
            mod5.Comments = new object[,]
            {
                { "Alex", "Fork" },
                { "Henry", "I'm good at smash" },
            };
            _modules.Add(mod5);

            Module mod55 = new Module();
            mod55.Title = "Database Integration in C#";
            mod55.Overview = "Applications developed today are primarily data driven. Many are built on Web Content Management Systems (Web CMS), which allow web developers to maintain content using an admin screen. Others are developed using forms to input data, which is then saved to the database. Regardless of the method, this data is then presented in a formatted way to users. \n This module will give you an overview of how we move data from the textbox of an application into a column in a database table.We will show you how to query the database and perform the four CRUD data operations: create, read, update, and delete. ";
            mod55.SMEs = new[] { "Zach Gay", "Ron Jones", "Craig Trulove", "Michael Buckman" };
            mod55.Checklist = new[] { "Set-up Visual Studio", "Win At Life", "Purchase Gorton's Fishsticks" };
            mod55.InstructionLink = "https://teams.microsoft.com/l/channel/19%3Af9d21f79034c4f6690ceed6586e73248%40thread.skype/tab%3A%3A937ecfbd-5b52-4d8c-8856-e5447c0e8f7e?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod55.Rating = new[] { 10, 8, 2 };
            mod55.Comments = new[,]
                {
                    { "Kam" , "YEET"},
                    { "Drew", "VS CODE IS BETTER"},
                };
            mod55.completionDate = new DateTime(2020, 7, 17);
            _modules.Add(mod55);

            Module mod6 = new Module();
            mod6.Title = "ASP.NET 101";
            mod6.Overview = "ASP.NET is Microsoft’s tool for web application development. It is used to build everything from a personal website to Office 365. ASP stands for Active Server Page and ASP.NET extends the idea of traditional ASP. In an ASP app the browser makes a request to a server, this request is then processed by the server and a response is generated and sent back to the browser in the form of an HTML web page.";
            mod6.SMEs = new[] { "George Chang", "Mike Ward", "Michael Yao", "Storm Anderson" };
            mod6.Checklist = new[]
            { "Make Fabrikam Website",
             "Do the thang",
            "Make page for each school!!!!",
            };
            mod6.InstructionLink = "https://teams.microsoft.com/l/channel/19%3A1435ed5a7d18478288473a4e72cf37f1%40thread.skype/tab%3A%3A1c021751-0d1f-494b-946e-8b79e82bc515?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod6.Rating = new[] { 10, 8, 2 };
            mod6.Comments = new object[,]
            {
                { "Alex", "Fork" },
                { "Henry", "I'm good at smash" },
            };
            _modules.Add(mod5);

            Module mod7 = new Module();
            mod7.Title = "Azure 101";
            mod7.Overview = "Azure (pronounced “AZ-uhr”) is Microsoft’s cloud computing platform. Cloud computing allows businesses and individuals to rent compute power and storage from a company, rather than having to maintain their own data centers. In the case of Azure, Microsoft rents out software they built, hosted on their servers and is responsible for maintaining the underlying infrastructure. With Azure’s “pay-as-you-go” pricing model, users are only billed for the resources they use. \n This module will give you a brief introduction to Cloud concepts and provide you with specific knowledge of Azure.Cloud solutions are constantly advancing and updates to documentation are made very frequently.It’s possible that some of the information and examples in this module will not align with more recent resources you find. That’s okay!Staying up to date with ever - changing technology is a big part of being a successful consultant. As always, feel free to reach out to your Great Start Guide, Career Counselor, or any other member of the team if you need help!";
            mod7.SMEs = new[] { "Zach Gay", "Ron Jones", "Craig Trulove", "Michael Buckman" };
            mod7.Checklist = new[] { "Set-up Visual Studio", "Win At Life", "Purchase Gorton's Fishsticks" };
            mod7.InstructionLink = "https://teams.microsoft.com/l/channel/19%3Af9d21f79034c4f6690ceed6586e73248%40thread.skype/tab%3A%3A937ecfbd-5b52-4d8c-8856-e5447c0e8f7e?groupId=cbb572f4-6cdd-467d-8a4b-8cef4e6f2b98&tenantId=243bd71d-cef7-442d-b37f-3ff10a3e2832";
            mod7.Rating = new[] { 10, 8, 2 };
            mod7.Comments = new[,]
                {
                    { "Kam" , "YEET"},
                    { "Drew", "VS CODE IS BETTER"},
                };
            mod7.completionDate = new DateTime(2020, 7, 17);
            _modules.Add(mod7);
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
                Password = "henryPass",
                IsAdmin = false
            };
            _LoginTable.Add(henrySignIn);

            Login drewSignIn = new Login
            {
                Username = "drew.taylor",
                Password = "drewPass",
                IsAdmin = false
            };
            _LoginTable.Add(drewSignIn);

            Login adminSignin = new Login {
                Username = "admin.admin",
                Password = "admin",
                IsAdmin = true
            };   
        }

        public static List<Models.Login> GetLogins()
        {
            return _LoginTable;
        }
    }

}