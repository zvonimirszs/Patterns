using Model_Patterns;
using Model_Patterns.Interfaces;
using Model_Patterns.Providers;
using Model_Patterns.Models.Logger;
using Model_Patterns.Models.Content;
using Patterns.App_Code;
using Patterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Patterns.Models.Authorization;

namespace Patterns.Controllers
{
    public class HomeController : Controller
    {
        
        private int _pageId = 1;        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //Pattern: Bridge
            /* 
             Ideja je da je moguće lako promijeniti tipova upisivanje logova.
             */
            #region Logger
            //Logger - na disk
            Log log = new LoggerProvider(Enumerations.Logger.File);
            //log.Logger = CreateLogger("");
            log.InsertLog(CreateLogger(""));
            log.InsertLog(CreateLogger("2"));
            //Logger - na db
            log = new LoggerProvider(Enumerations.Logger.Db);
            log.InsertLog(CreateLogger(""));
            #endregion

            return View();
        }

        public ActionResult Document(string sopi)
        { 
            return View();
        }

        private Logger CreateLogger(string key)
        {
            return new Logger
            {
                PageId = _pageId,
                Url = "Home",
                DocumentKey = key,
                Date = DateTime.Now
            };

        }
    }
}
