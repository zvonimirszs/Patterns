using Model_Patterns.Models.Content;
using Model_Patterns.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Patterns.Models.Authorization;
using Model_Patterns.Interfaces;
using Patterns.App_Code;
using Model_Patterns;
using Patterns.Aspects;

namespace Patterns.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        [CheckAuthorization]
        public ActionResult Index(string sopi)
        {
            DataProvider dataProvider = new DataProvider();
            IDocument document = dataProvider.GetDocumentByKey(sopi);
            HttpContext.Session["Document"] = document;

            return View(document); 
        }

        [CheckAuthorization]
        public ActionResult Reporting(string sopi, Enumerations.Reporting type)
        {
            //Pattern: Facade
            DataProvider dataProvider = new DataProvider();
            IDocument document = dataProvider.GetDocumentByKey(sopi);
            
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
            return View("Index", document);
        }

        [ExceptionHandlerAspect(AspectPriority = 0)]
        public ActionResult Create()
        {
            //Pattern: Template
            Law legalDocument = new Law();
            legalDocument.DocTitle = "Legal document";
            legalDocument.Segments = new List<Segment>();

            legalDocument.CreateDocument();

            return View("Index", legalDocument);
        }
    }
}
