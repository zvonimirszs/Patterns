using Model_Patterns.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Patterns.Models.Authorization;
using Model_Patterns.Interfaces;
using Patterns.App_Code;
using Model_Patterns;

namespace Patterns.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        [CheckAuthorization]
        public ActionResult Index(string sopi)
        {
            DataProvider data = new DataProvider();
            IDocument doc = data.GetDocument(sopi);
            HttpContext.Session["Document"] = doc;

            return View(doc); 
        }

        [CheckAuthorization]
        public ActionResult Reporting(string sopi, Enumerations.Reporting type)
        {
            //Pattern: Facade
            DataProvider data = new DataProvider();
            IDocument doc = data.GetDocument(sopi);
            
            switch (type)
            {
                case Enumerations.Reporting.Pdf:
                    //TODO: kreiraj reporting za PDF
                    break;
                case Enumerations.Reporting.Html:
                    //TODO: kreiraj reporting za Html
                    break;
                default:
                    //TODO: kreiraj reporting za PDF
                    break;
            }
            return View("Index", doc);
        }

        public ActionResult Create()
        {
            //Pattern: Template
            Law doc = new Law();
            doc.DocTitle = "Bla";
            doc.Segments = new List<Segment>();
            doc.Create();

            return View("Index", doc);
        }
    }
}
