﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;



namespace Boot_Track.Models
{
    
    public class Session
    {
        
        public List<Intern> interns = new List<Intern>();

        public List<List<Progress>> progress = new List<List<Progress>>();

        public List<Module> modules = new List<Module>();

        public List<Login> logins = new List<Login>();

        public Email email = new Email();

        public Module CurrModule = new Module();

        public string AbsolutePath;

        public void GetProgress()
        {
            if (!Database.GetProgress().Any())
            {
                Database.InitProgress();
                progress = Database.GetProgress();
            }
            else
            {
                progress = Database.GetProgress();
            }
        }

        public void GetInterns()
        {
            if (!Database.GetInterns().Any())
            {
                Database.InitIntern();
                interns = Database.GetInterns();
            }
            else
            {
                interns = Database.GetInterns();
            }
        }

        public Intern GetIntern(string username)
        {
            GetInterns();
            string[] names = username.Split(new Char[] { '.' });
            Intern notFoundIntern = new Intern();

            foreach(var intrn in interns)
            {
                if(intrn.FirstName.ToLower() == names[0] && intrn.LastName.ToLower() == names[1])
                {
                    return intrn;
                }
            }

            return notFoundIntern;
        }

        public void GetModules()
        {
            if (!Database.GetModules().Any())
            {
                Database.InitModules();
                modules = Database.GetModules();
            }
            else
            {
                //Database.InitModules();
                modules = Database.GetModules();
            }
        }

        public void GetLogins()
        {
            if (!Database.GetLogins().Any())
            {
                Database.InitLogin();
                logins = Database.GetLogins();
            }
            else
            {
                logins = Database.GetLogins();
            }
        }

        public void SetProgressChecklist(Intern internParam, Module moduleParam, int num, bool state)
        {
            Database.SetProgressChecklist(internParam, moduleParam, num, state);
        }

        public bool GetProgressChecklist(Intern internParam, Module moduleParam, int num)
        {
            return Database.GetProgressChecklist(internParam, moduleParam, num);
        }

        public Progress GetProgress(Intern internParam, Module moduleParam)
        {
            return Database.GetProgress(internParam, moduleParam);
        }
    }
}